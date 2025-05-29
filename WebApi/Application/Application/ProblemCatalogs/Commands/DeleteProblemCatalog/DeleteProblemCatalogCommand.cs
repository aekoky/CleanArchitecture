using CleanArchitecture.Application.Application.Problems.Events;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Commands.DeleteProblemCatalog;

public record DeleteProblemCatalogCommand(int Id) : IRequest;

public class DeleteProblemCatalogCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteProblemCatalogCommand>
{
    public async Task Handle(DeleteProblemCatalogCommand request, CancellationToken cancellationToken)
    {
        List<string> cacheKeys = [];
        var problemCatalog = await dbContext.ProblemCatalogs
            .SingleOrDefaultAsync(problemCatalog => problemCatalog.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(ProblemCatalog), request.Id);
        var transaction = await dbContext.BeginTransactionAsync(cancellationToken);
        try
        {
            var problemCategories = await dbContext.ProblemCategories.Where(problemCatalegory => problemCatalegory.ProblemCatalogId == problemCatalog.Id).ToListAsync(cancellationToken);
            foreach (var problemCategory in problemCategories)
            {
                var problems = await dbContext.Problems
                .Where(problem => problem.ProblemCategoryId == problemCategory.Id)
                .ToListAsync(cancellationToken);

                dbContext.Problems.RemoveRange(problems);
                foreach (var problem in problems)
                    cacheKeys.Add($"{nameof(Problem)}_{problem.Id}");

                await dbContext.SaveChangesAsync(cancellationToken);
            }
            dbContext.ProblemCategories.RemoveRange(problemCategories);
            foreach (var problemCategory in problemCategories)
                cacheKeys.Add($"{nameof(ProblemCategory)}_{problemCategory.Id}");

            await dbContext.SaveChangesAsync(cancellationToken);

            dbContext.ProblemCatalogs.Remove(problemCatalog);
            cacheKeys.Add($"{nameof(ProblemCatalog)}_{problemCatalog.Id}");
            problemCatalog.AddDomainEvent(new ProblemsUpdatedEvent([.. cacheKeys]));

            await dbContext.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(CancellationToken.None);
            throw;
        }
    }

}

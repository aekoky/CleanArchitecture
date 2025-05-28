using MediatR;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Application.Problems.Events;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Commands.DeleteProblemCatalog;

public record DeleteProblemCatalogCommand(int Id) : IRequest;

public class DeleteProblemCatalogCommandHandler(IApplicationDbContext dbContext, IDistributedCache cache) : IRequestHandler<DeleteProblemCatalogCommand>
{
    public async Task Handle(DeleteProblemCatalogCommand request, CancellationToken cancellationToken)
    {
        var problemCatalog = await dbContext.ProblemCatalogs
            .SingleOrDefaultAsync(problemCatalog => problemCatalog.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(ProblemCatalog), request.Id);
        problemCatalog.AddDomainEvent(new ProblemsUpdatedEvent());
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
                    cache.SetAutoJson<Problem>($"{nameof(Problem)}_{problem.Id}");

                await dbContext.SaveChangesAsync(cancellationToken);
            }
            dbContext.ProblemCategories.RemoveRange(problemCategories);
            foreach (var problemCategory in problemCategories)
                cache.SetAutoJson<ProblemCategory>($"{nameof(ProblemCategory)}_{problemCategory.Id}");

            await dbContext.SaveChangesAsync(cancellationToken);

            dbContext.ProblemCatalogs.Remove(problemCatalog);
            cache.SetAutoJson<ProblemCatalog>($"{nameof(ProblemCatalog)}_{problemCatalog.Id}");

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

using MediatR;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Commands.DeleteProblemCatalog;

public record DeleteProblemCatalogCommand(int Id) : IRequest;

public class DeleteProblemCatalogCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteProblemCatalogCommand>
{
    public async Task Handle(DeleteProblemCatalogCommand request, CancellationToken cancellationToken)
    {
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
                await dbContext.SaveChangesAsync(cancellationToken);
            }
            dbContext.ProblemCategories.RemoveRange(problemCategories);
            await dbContext.SaveChangesAsync(cancellationToken);

            dbContext.ProblemCatalogs.Remove(problemCatalog);
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

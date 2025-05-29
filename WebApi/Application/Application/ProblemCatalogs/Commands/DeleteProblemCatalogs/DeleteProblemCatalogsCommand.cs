using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CleanArchitecture.Application.Application.Problems.Events;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Commands.DeleteProblemCatalogs;

public record DeleteProblemCatalogsCommand(int[] Ids) : IRequest;

public class DeleteProblemCatalogsCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteProblemCatalogsCommand>
{
    public async Task Handle(DeleteProblemCatalogsCommand request, CancellationToken cancellationToken)
    {
        List<string> cacheKeys = [];
        var problemCatalogs = await dbContext.ProblemCatalogs
            .Where(problemCatalog => request.Ids.Contains(problemCatalog.Id))
            .ToListAsync(cancellationToken);
        if (problemCatalogs.Count == 0)
            return;
        var transaction = await dbContext.BeginTransactionAsync(cancellationToken);
        try
        {
            foreach (var problemCatalog in problemCatalogs)
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
            }
            foreach (var problemCatalog in problemCatalogs)
                cacheKeys.Add($"{nameof(ProblemCatalog)}_{problemCatalog.Id}");

            problemCatalogs[0].AddDomainEvent(new ProblemsUpdatedEvent([.. cacheKeys]));
            dbContext.ProblemCatalogs.RemoveRange(problemCatalogs);
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

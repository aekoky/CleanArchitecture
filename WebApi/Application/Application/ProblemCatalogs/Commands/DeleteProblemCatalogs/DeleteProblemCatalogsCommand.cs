using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Commands.DeleteProblemCatalogs;

public record DeleteProblemCatalogsCommand(int[] Ids) : IRequest;

public class DeleteProblemCatalogsCommandHandler(IApplicationDbContext dbContext, IDistributedCache cache) : IRequestHandler<DeleteProblemCatalogsCommand>
{
    public async Task Handle(DeleteProblemCatalogsCommand request, CancellationToken cancellationToken)
    {
        var transaction = await dbContext.BeginTransactionAsync(cancellationToken);
        try
        {
            if (request.Ids.Length != 0)
            {
                var problemCatalogs = await dbContext.ProblemCatalogs
                    .Where(problemCatalog => request.Ids.Contains(problemCatalog.Id))
                    .ToListAsync(cancellationToken);
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
                            cache.SetAutoJson<Problem>($"{nameof(Problem)}_{problem.Id}");

                        await dbContext.SaveChangesAsync(cancellationToken);
                    }
                    dbContext.ProblemCategories.RemoveRange(problemCategories);
                    foreach (var problemCategory in problemCategories)
                        cache.SetAutoJson<ProblemCategory>($"{nameof(ProblemCategory)}_{problemCategory.Id}");

                    await dbContext.SaveChangesAsync(cancellationToken);
                }

                dbContext.ProblemCatalogs.RemoveRange(problemCatalogs);
                foreach (var problemCatalog in problemCatalogs)
                    cache.SetAutoJson<ProblemCatalog>($"{nameof(ProblemCatalog)}_{problemCatalog.Id}");
                
                await dbContext.SaveChangesAsync(cancellationToken);
            }

            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(CancellationToken.None);
            throw;
        }
    }
}

using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CleanArchitecture.Application.Application.Problems.Events;

namespace CleanArchitecture.Application.Application.ProblemCategories.Commands.DeleteProblemCategories;

public record DeleteProblemCategoriesCommand(int[] Ids) : IRequest;

public class DeleteProblemCategoriesCommandHandler(IApplicationDbContext dbContext, IDistributedCache cache) : IRequestHandler<DeleteProblemCategoriesCommand>
{
    public async Task Handle(DeleteProblemCategoriesCommand request, CancellationToken cancellationToken)
    {
        var transaction = await dbContext.BeginTransactionAsync(cancellationToken);
        try
        {
            if (request.Ids.Length != 0)
            {
                var problemCategories = await dbContext.ProblemCategories
                    .Where(problemCategory => request.Ids.Contains(problemCategory.Id))
                    .ToListAsync(cancellationToken);
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
                if (problemCategories.Count != 0)
                    problemCategories[0]?.AddDomainEvent(new ProblemsUpdatedEvent());
                dbContext.ProblemCategories.RemoveRange(problemCategories);
                foreach (var problemCategory in problemCategories)
                    cache.SetAutoJson<ProblemCategory>($"{nameof(ProblemCategory)}_{problemCategory.Id}");

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

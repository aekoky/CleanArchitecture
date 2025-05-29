using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CleanArchitecture.Application.Application.Problems.Events;

namespace CleanArchitecture.Application.Application.ProblemCategories.Commands.DeleteProblemCategories;

public record DeleteProblemCategoriesCommand(int[] Ids) : IRequest;

public class DeleteProblemCategoriesCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteProblemCategoriesCommand>
{
    public async Task Handle(DeleteProblemCategoriesCommand request, CancellationToken cancellationToken)
    {
        List<string> cacheKeys = [];
        var problemCategories = await dbContext.ProblemCategories
            .Where(problemCategory => request.Ids.Contains(problemCategory.Id))
            .ToListAsync(cancellationToken);
        if (problemCategories.Count == 0)
            return;
        var transaction = await dbContext.BeginTransactionAsync(cancellationToken);
        try
        {
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
            foreach (var problemCategory in problemCategories)
                cacheKeys.Add($"{nameof(ProblemCategory)}_{problemCategory.Id}");
            dbContext.ProblemCategories.RemoveRange(problemCategories);

            problemCategories[0].AddDomainEvent(new ProblemsUpdatedEvent([.. cacheKeys]));
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

using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CleanArchitecture.Application.Application.ProblemCategories.Commands.DeleteProblemCategories;

public record DeleteProblemCategoriesCommand(int[] Ids) : IRequest;

public class DeleteProblemCategoriesCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteProblemCategoriesCommand>
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
                    await dbContext.SaveChangesAsync(cancellationToken);
                }

                dbContext.ProblemCategories.RemoveRange(problemCategories);

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

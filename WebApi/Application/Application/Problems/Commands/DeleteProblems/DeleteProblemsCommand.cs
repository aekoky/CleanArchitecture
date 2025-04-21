using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CleanArchitecture.Application.Application.Problems.Commands.DeleteProblems;

public record DeleteProblemsCommand(int[] Ids) : IRequest;

public class DeleteProblemsCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteProblemsCommand>
{
    public async Task Handle(DeleteProblemsCommand request, CancellationToken cancellationToken)
    {
        var transaction = await dbContext.BeginTransactionAsync(cancellationToken);
        try
        {
            if (request.Ids.Length != 0)
            {
                var problems = await dbContext.Problems
                    .Where(problem => request.Ids.Contains(problem.Id))
                    .ToListAsync(cancellationToken);

                dbContext.Problems.RemoveRange(problems);
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

using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CleanArchitecture.Application.Application.Problems.Events;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Application.Problems.Commands.DeleteProblems;

public record DeleteProblemsCommand(int[] Ids) : IRequest;

public class DeleteProblemsCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteProblemsCommand>
{
    public async Task Handle(DeleteProblemsCommand request, CancellationToken cancellationToken)
    {
        var problems = await dbContext.Problems
            .Where(problem => request.Ids.Contains(problem.Id))
            .ToListAsync(cancellationToken);
        if (problems.Count == 0)
            return;

        string[] cacheKeys = problems.Select(problem => $"{nameof(Problem)}_{problem.Id}").ToArray();
        problems[0].AddDomainEvent(new ProblemsUpdatedEvent(cacheKeys));
        dbContext.Problems.RemoveRange(problems);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}

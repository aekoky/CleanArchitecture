using CleanArchitecture.Application.Application.Problems.Events;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace CleanArchitecture.Application.Application.Problems.Commands.CreateProblem;

public record CreateProblemCommand : IRequest<int>
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public int? ProblemCategoryId { get; set; }
}

public class CreateProblemCommandHandler(IApplicationDbContext dbContext, IDistributedCache cache) : IRequestHandler<CreateProblemCommand, int>
{
    public async Task<int> Handle(CreateProblemCommand request, CancellationToken cancellationToken)
    {
        var problem = new Problem
        {
            Name = request.Name,
            Description = request.Description,
            ProblemCategoryId = request.ProblemCategoryId,
        };
        problem.AddDomainEvent(new ProblemsUpdatedEvent());

        dbContext.Problems.Add(problem);

        await dbContext.SaveChangesAsync(cancellationToken);
        await cache.SetAutoJsonAsync($"{nameof(Problem)}_{problem.Id}", problem, cancellationToken: cancellationToken);

        return problem.Id;
    }
}

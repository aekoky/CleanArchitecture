using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using MediatR;
using CleanArchitecture.Application.Application.Problems.Events;

namespace CleanArchitecture.Application.Application.Problems.Commands.UpdateProblem;

public record UpdateProblemCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? ProblemCategoryId { get; set; }
}

public class UpdateProblemCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<UpdateProblemCommand>
{
    public async Task Handle(UpdateProblemCommand request, CancellationToken cancellationToken)
    {
        var problem = await dbContext.Problems
            .SingleOrDefaultAsync(problem => problem.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Problem), request.Id);
        problem.AddDomainEvent(new ProblemsUpdatedEvent());

        problem.Name = request.Name ?? problem.Name;
        problem.Description = request.Description;
        problem.ProblemCategoryId = request.ProblemCategoryId;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}

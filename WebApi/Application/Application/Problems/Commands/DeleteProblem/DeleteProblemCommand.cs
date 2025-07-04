﻿using MediatR;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Application.Problems.Events;

namespace CleanArchitecture.Application.Application.Problems.Commands.DeleteProblem;

public record DeleteProblemCommand(int Id) : IRequest;

public class DeleteProblemCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteProblemCommand>
{
    public async Task Handle(DeleteProblemCommand request, CancellationToken cancellationToken)
    {
        var problem = await dbContext.Problems
            .SingleOrDefaultAsync(problem => problem.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Problem), request.Id);
        dbContext.Problems.Remove(problem);
        problem.AddDomainEvent(new ProblemsUpdatedEvent([$"{nameof(Problem)}_{problem.Id}"]));
        await dbContext.SaveChangesAsync(cancellationToken);
    }

}

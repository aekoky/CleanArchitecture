using MediatR;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Application.Problems.Commands.DeleteProblem;

public record DeleteProblemCommand(int Id) : IRequest;

public class DeleteProblemCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteProblemCommand>
{
    public async Task Handle(DeleteProblemCommand request, CancellationToken cancellationToken)
    {
        var problem = await dbContext.Problems
            .SingleOrDefaultAsync(problem => problem.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Problem), request.Id);
        var transaction = await dbContext.BeginTransactionAsync(cancellationToken);
        try
        {
            dbContext.Problems.Remove(problem);
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

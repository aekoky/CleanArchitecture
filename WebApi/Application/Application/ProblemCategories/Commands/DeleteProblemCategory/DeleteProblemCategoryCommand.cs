using MediatR;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Application.ProblemCategories.Commands.DeleteProblemCategory;

public record DeleteProblemCategoryCommand(int Id) : IRequest;

public class DeleteProblemCategoryCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteProblemCategoryCommand>
{
    public async Task Handle(DeleteProblemCategoryCommand request, CancellationToken cancellationToken)
    {
        var problemCategory = await dbContext.ProblemCategories
            .SingleOrDefaultAsync(problemCategory => problemCategory.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(ProblemCategory), request.Id);
        var transaction = await dbContext.BeginTransactionAsync(cancellationToken);
        try
        {
            var problems = await dbContext.Problems
            .Where(problem => problem.ProblemCategoryId == problemCategory.Id)
            .ToListAsync(cancellationToken);

            dbContext.Problems.RemoveRange(problems);
            await dbContext.SaveChangesAsync(cancellationToken);

            dbContext.ProblemCategories.Remove(problemCategory);
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

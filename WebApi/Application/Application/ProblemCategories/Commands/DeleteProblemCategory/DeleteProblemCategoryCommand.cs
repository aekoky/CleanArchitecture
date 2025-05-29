using MediatR;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Application.Problems.Events;

namespace CleanArchitecture.Application.Application.ProblemCategories.Commands.DeleteProblemCategory;

public record DeleteProblemCategoryCommand(int Id) : IRequest;

public class DeleteProblemCategoryCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteProblemCategoryCommand>
{
    public async Task Handle(DeleteProblemCategoryCommand request, CancellationToken cancellationToken)
    {
        List<string> cacheKeys = [];
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
            foreach (var problem in problems)
                cacheKeys.Add($"{nameof(Problem)}_{problem.Id}");
            if (problems.Count != 0)
                problems[0]?.AddDomainEvent(new ProblemsUpdatedEvent());
            await dbContext.SaveChangesAsync(cancellationToken);

            dbContext.ProblemCategories.Remove(problemCategory);
            cacheKeys.Add($"{nameof(ProblemCategory)}_{problemCategory.Id}");
            problemCategory.AddDomainEvent(new ProblemsUpdatedEvent([.. cacheKeys]));

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

using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Application.Problems.Events;

namespace CleanArchitecture.Application.Application.ProblemCategories.Commands.UpdateProblemCategory;

public record UpdateProblemCategoryCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? ProblemCatalogId { get; set; }
}

public class UpdateProblemCategoryCommandHandler(IApplicationDbContext dbContext, IDistributedCache cache) : IRequestHandler<UpdateProblemCategoryCommand>
{
    public async Task Handle(UpdateProblemCategoryCommand request, CancellationToken cancellationToken)
    {
        var problemCategory = await dbContext.ProblemCategories
            .SingleOrDefaultAsync(problemCategory => problemCategory.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(ProblemCategory), request.Id);
        problemCategory.AddDomainEvent(new ProblemsUpdatedEvent());

        problemCategory.Name = request.Name ?? problemCategory.Name;
        problemCategory.Description = request.Description;
        problemCategory.ProblemCatalogId = request.ProblemCatalogId;

        await dbContext.SaveChangesAsync(cancellationToken);
        await cache.SetAutoJsonAsync($"{nameof(ProblemCategory)}_{problemCategory.Id}", problemCategory, cancellationToken: cancellationToken);
    }
}

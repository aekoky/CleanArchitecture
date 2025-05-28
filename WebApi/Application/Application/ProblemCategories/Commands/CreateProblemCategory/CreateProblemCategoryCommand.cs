using CleanArchitecture.Application.Application.Problems.Events;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace CleanArchitecture.Application.Application.ProblemCategories.Commands.CreateProblemCategory;

public record CreateProblemCategoryCommand : IRequest<int>
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public int? ProblemCatalogId { get; set; }
}

public class CreateProblemCategoryCommandHandler(IApplicationDbContext dbContext, IDistributedCache cache) : IRequestHandler<CreateProblemCategoryCommand, int>
{
    public async Task<int> Handle(CreateProblemCategoryCommand request, CancellationToken cancellationToken)
    {
        var problemCategory = new ProblemCategory
        {
            Name = request.Name,
            Description = request.Description,
            ProblemCatalogId = request.ProblemCatalogId
        };
        problemCategory.AddDomainEvent(new ProblemsUpdatedEvent());
        dbContext.ProblemCategories.Add(problemCategory);

        await dbContext.SaveChangesAsync(cancellationToken);
        cache.SetAutoJson($"{nameof(ProblemCategory)}_{problemCategory.Id}", problemCategory);

        return problemCategory.Id;
    }
}

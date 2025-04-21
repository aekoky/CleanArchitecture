using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Application.ProblemCategories.Commands.CreateProblemCategory;

public record CreateProblemCategoryCommand : IRequest<int>
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public int? ProblemCatalogId { get; set; }
}

public class CreateProblemCategoryCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<CreateProblemCategoryCommand, int>
{
    public async Task<int> Handle(CreateProblemCategoryCommand request, CancellationToken cancellationToken)
    {
        var problemCategory = new ProblemCategory
        {
            Name = request.Name,
            Description = request.Description,
            ProblemCatalogId = request.ProblemCatalogId
        };

        dbContext.ProblemCategories.Add(problemCategory);

        await dbContext.SaveChangesAsync(cancellationToken);

        return problemCategory.Id;
    }
}

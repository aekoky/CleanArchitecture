using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Application.ProblemCategories.Commands.UpdateProblemCategory;

public record UpdateProblemCategoryCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? ProblemCatalogId { get; set; }
}

public class UpdateProblemCategoryCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<UpdateProblemCategoryCommand>
{
    public async Task Handle(UpdateProblemCategoryCommand request, CancellationToken cancellationToken)
    {
        var problemCategoryEntity = await dbContext.ProblemCategories
            .SingleOrDefaultAsync(problemCategory => problemCategory.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(ProblemCategory), request.Id);

        problemCategoryEntity.Name = request.Name ?? problemCategoryEntity.Name;
        problemCategoryEntity.Description = request.Description;
        problemCategoryEntity.ProblemCatalogId = request.ProblemCatalogId;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}

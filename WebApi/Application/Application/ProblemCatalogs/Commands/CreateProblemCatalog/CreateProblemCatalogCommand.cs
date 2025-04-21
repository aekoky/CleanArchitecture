using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Commands.CreateProblemCatalog;

public record CreateProblemCatalogCommand : IRequest<int>
{
    public required string Name { get; set; }

    public string? Description { get; set; }
}

public class CreateProblemCatalogCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<CreateProblemCatalogCommand, int>
{
    public async Task<int> Handle(CreateProblemCatalogCommand request, CancellationToken cancellationToken)
    {
        var problemCatalog = new ProblemCatalog
        {
            Name = request.Name,
            Description = request.Description,
        };

        dbContext.ProblemCatalogs.Add(problemCatalog);

        await dbContext.SaveChangesAsync(cancellationToken);

        return problemCatalog.Id;
    }
}

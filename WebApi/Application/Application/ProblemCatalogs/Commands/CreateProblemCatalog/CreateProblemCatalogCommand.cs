using CleanArchitecture.Application.Application.Problems.Events;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Commands.CreateProblemCatalog;

public record CreateProblemCatalogCommand : IRequest<int>
{
    public required string Name { get; set; }

    public string? Description { get; set; }
}

public class CreateProblemCatalogCommandHandler(IApplicationDbContext dbContext, IDistributedCache cache) : IRequestHandler<CreateProblemCatalogCommand, int>
{
    public async Task<int> Handle(CreateProblemCatalogCommand request, CancellationToken cancellationToken)
    {
        var problemCatalog = new ProblemCatalog
        {
            Name = request.Name,
            Description = request.Description,
        };

        problemCatalog.AddDomainEvent(new ProblemsUpdatedEvent());
        dbContext.ProblemCatalogs.Add(problemCatalog);

        await dbContext.SaveChangesAsync(cancellationToken);
        await cache.SetAutoJsonAsync($"{nameof(ProblemCatalog)}_{problemCatalog.Id}", problemCatalog, cancellationToken: cancellationToken);

        return problemCatalog.Id;
    }
}

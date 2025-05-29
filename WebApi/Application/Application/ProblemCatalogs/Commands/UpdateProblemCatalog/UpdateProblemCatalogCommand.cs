using CleanArchitecture.Application.Application.Problems.Events;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Commands.UpdateProblemCatalog;

public record UpdateProblemCatalogCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}

public class UpdateProblemCatalogCommandHandler(IApplicationDbContext dbContext, IDistributedCache cache) : IRequestHandler<UpdateProblemCatalogCommand>
{
    public async Task Handle(UpdateProblemCatalogCommand request, CancellationToken cancellationToken)
    {
        var problemCatalog = await dbContext.ProblemCatalogs
            .SingleOrDefaultAsync(problemCatalog => problemCatalog.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(ProblemCatalog), request.Id);

        problemCatalog.AddDomainEvent(new ProblemsUpdatedEvent());
        problemCatalog.Name = request.Name ?? problemCatalog.Name;
        problemCatalog.Description = request.Description;

        await dbContext.SaveChangesAsync(cancellationToken);
        await cache.SetAutoJsonAsync($"{nameof(ProblemCatalog)}_{problemCatalog.Id}", problemCatalog, cancellationToken: cancellationToken);
    }
}

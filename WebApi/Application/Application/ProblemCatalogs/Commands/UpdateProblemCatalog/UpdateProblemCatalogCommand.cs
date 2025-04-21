using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Commands.UpdateProblemCatalog;

public record UpdateProblemCatalogCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}

public class UpdateProblemCatalogCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<UpdateProblemCatalogCommand>
{
    public async Task Handle(UpdateProblemCatalogCommand request, CancellationToken cancellationToken)
    {
        var problemCatalogEntity = await dbContext.ProblemCatalogs
            .SingleOrDefaultAsync(problemCatalog => problemCatalog.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(ProblemCatalog), request.Id);

        problemCatalogEntity.Name = request.Name ?? problemCatalogEntity.Name;
        problemCatalogEntity.Description = request.Description;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}

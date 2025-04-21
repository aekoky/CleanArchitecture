using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.DTOs;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Queries.GetProblemCatalogById;

public record GetProblemCatalogByIdQuery : IRequest<ProblemCatalogDto>
{
    public int Id { get; init; }
}

public class GetProblemCatalogByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) : IRequestHandler<GetProblemCatalogByIdQuery, ProblemCatalogDto>
{
    public async Task<ProblemCatalogDto> Handle(GetProblemCatalogByIdQuery request, CancellationToken cancellationToken)
    {
        var problemCatalog = await dbContext.ProblemCatalogs
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(ProblemCatalog), request.Id);

        return mapper.Map<ProblemCatalogDto>(problemCatalog);
    }
}

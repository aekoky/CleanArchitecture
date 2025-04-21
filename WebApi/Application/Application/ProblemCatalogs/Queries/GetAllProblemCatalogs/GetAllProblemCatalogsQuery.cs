using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.DTOs;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Queries.GetAllProblemCatalogs;

public record GetAllProblemCatalogsQuery : IRequest<List<ProblemCatalogDto>>;

public class GetAllProblemCatalogsQueryHandler(IApplicationDbContext dbContext, IMapper mapper) : IRequestHandler<GetAllProblemCatalogsQuery, List<ProblemCatalogDto>>
{
    public async Task<List<ProblemCatalogDto>> Handle(GetAllProblemCatalogsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.ProblemCatalogs
            .AsNoTracking()
            .OrderBy(problemCatalog => problemCatalog.Name)
            .ThenByDescending(problemCatalog => problemCatalog.Created)
            .ProjectTo<ProblemCatalogDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

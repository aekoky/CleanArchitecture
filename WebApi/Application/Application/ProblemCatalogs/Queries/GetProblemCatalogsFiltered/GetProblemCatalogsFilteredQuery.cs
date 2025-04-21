using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.DTOs;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Queries.GetProblemCatalogsFiltered;

public record GetProblemCatalogsFilteredQuery : IRequest<List<ProblemCatalogDto>>
{
    public string? Keyword { get; set; }
}

public class GetProblemCatalogsFilteredQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetProblemCatalogsFilteredQuery, List<ProblemCatalogDto>>
{
    public async Task<List<ProblemCatalogDto>> Handle(GetProblemCatalogsFilteredQuery request, CancellationToken cancellationToken)
    {
        var problemCatalogs = context.ProblemCatalogs
            .AsNoTracking();

        if (!string.IsNullOrEmpty(request.Keyword))
            problemCatalogs = problemCatalogs.Where(problemCatalog =>
            problemCatalog.Name.Contains(request.Keyword) ||
            (!string.IsNullOrEmpty(problemCatalog.Description) && problemCatalog.Description.Contains(request.Keyword)));

        return await problemCatalogs
             .ProjectTo<ProblemCatalogDto>(mapper.ConfigurationProvider)
             .ToListAsync(cancellationToken);
    }
}

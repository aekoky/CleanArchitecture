using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.DTOs;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Queries.GetProblemCatalogSuggestions;

public record GetProblemCatalogSuggestionsQuery : IRequest<ICollection<ProblemCatalogDto>>
{
    public string? Keyword { get; set; }

    public List<int> IncludedProblemCatalogs { get; set; } = [];
}

public class GetProblemCatalogSuggestionQueryHandler(IApplicationDbContext dbContext, IMapper mapper) : IRequestHandler<GetProblemCatalogSuggestionsQuery, ICollection<ProblemCatalogDto>>
{
    public async Task<ICollection<ProblemCatalogDto>> Handle(GetProblemCatalogSuggestionsQuery request, CancellationToken cancellationToken)
    {
        var problemCatalogs = dbContext.ProblemCatalogs
            .AsNoTracking();

        if (!string.IsNullOrEmpty(request.Keyword))
            problemCatalogs = problemCatalogs.Where(problemCatalog =>
            problemCatalog.Name.Contains(request.Keyword) ||
            (!string.IsNullOrEmpty(problemCatalog.Description) && problemCatalog.Description.Contains(request.Keyword)));
        
        var problemCatalogsSuggestions = await problemCatalogs.Take(20).ToListAsync(cancellationToken);
        var problemCatalogsSuggestionsIds = problemCatalogsSuggestions.Select(problemCatalog => problemCatalog.Id).ToList();

        if (request.IncludedProblemCatalogs.Count != 0)
            problemCatalogsSuggestions.AddRange(dbContext.ProblemCatalogs.Where(problemCatalog => request.IncludedProblemCatalogs.Contains(problemCatalog.Id) && !problemCatalogsSuggestionsIds.Contains(problemCatalog.Id)).AsNoTracking());

        return mapper.Map<ICollection<ProblemCatalogDto>>(problemCatalogsSuggestions);
    }
}

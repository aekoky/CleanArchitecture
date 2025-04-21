using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.DTOs;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Application.ProblemCategories.Queries.GetProblemCategoriesFiltered;

public record GetProblemCategoriesFilteredQuery : IRequest<List<ProblemCategoryDto>>
{
    public string? Keyword { get; set; }

    public int? ProblemCatalogId { get; set; }
}

public class GetProblemCategoriesFilteredQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetProblemCategoriesFilteredQuery, List<ProblemCategoryDto>>
{
    public async Task<List<ProblemCategoryDto>> Handle(GetProblemCategoriesFilteredQuery request, CancellationToken cancellationToken)
    {
        var problemCategories = context.ProblemCategories
            .AsNoTracking();

        if (!string.IsNullOrEmpty(request.Keyword))
            problemCategories = problemCategories.Where(problemCategory =>
            problemCategory.Name.Contains(request.Keyword) ||
            (!string.IsNullOrEmpty(problemCategory.Description) && problemCategory.Description.Contains(request.Keyword)));

        if (request.ProblemCatalogId.HasValue)
            problemCategories = problemCategories.Where(problemCategory => problemCategory.ProblemCatalogId == request.ProblemCatalogId);

        return await problemCategories.OrderBy(problemCategory => problemCategory.Name)
                                      .ThenByDescending(problemCategory => problemCategory.Created)
                                      .ProjectTo<ProblemCategoryDto>(mapper.ConfigurationProvider)
                                      .ToListAsync(cancellationToken);
    }
}

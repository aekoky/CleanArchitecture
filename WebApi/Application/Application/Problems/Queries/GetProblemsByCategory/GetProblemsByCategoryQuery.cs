using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.DTOs;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Application.Problems.Queries.GetProblemsByCategory;

public record GetProblemsByCategoryQuery : IRequest<List<ProblemDto>>
{
    public List<int>? ProblemCategoryIds { get; init; }

    public List<int>? ProblemCatalogIds { get; init; }
}

public class GetProblemsByCategoryQueryHandler(IApplicationDbContext dbContext, IMapper mapper) : IRequestHandler<GetProblemsByCategoryQuery, List<ProblemDto>>
{
    public async Task<List<ProblemDto>> Handle(GetProblemsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var problems = dbContext.Problems
            .Include(problems => problems.ProblemCategory)
            .ThenInclude(problemCategory => problemCategory!.ProblemCatalog)
            .AsNoTracking();
        if (request.ProblemCategoryIds != null && request.ProblemCategoryIds.Count != 0 && request.ProblemCatalogIds != null && request.ProblemCatalogIds.Count != 0)
        {
            if (request.ProblemCategoryIds != null && request.ProblemCategoryIds.Count != 0)
                problems = problems.Where(problem =>
                (problem.ProblemCategoryId.HasValue && request.ProblemCategoryIds.Contains(problem.ProblemCategoryId.Value)) ||
                (problem.ProblemCategoryId.HasValue && problem.ProblemCategory != null && problem.ProblemCategory.ProblemCatalogId.HasValue && request.ProblemCatalogIds.Contains(problem.ProblemCategory.ProblemCatalogId.Value))
                );

        }
        else if ((request.ProblemCategoryIds != null && request.ProblemCategoryIds.Count != 0) || (request.ProblemCatalogIds != null && request.ProblemCatalogIds.Count != 0))
        {
            if (request.ProblemCategoryIds != null && request.ProblemCategoryIds.Count != 0)
                problems = problems.Where(problem => problem.ProblemCategoryId.HasValue && request.ProblemCategoryIds.Contains(problem.ProblemCategoryId.Value));

            if (request.ProblemCatalogIds != null && request.ProblemCatalogIds.Count != 0)
                problems = problems.Where(problem => problem.ProblemCategoryId.HasValue && problem.ProblemCategory != null && problem.ProblemCategory.ProblemCatalogId.HasValue && request.ProblemCatalogIds.Contains(problem.ProblemCategory.ProblemCatalogId.Value));
        }

        return await problems
             .ProjectTo<ProblemDto>(mapper.ConfigurationProvider)
             .ToListAsync(cancellationToken);
    }
}

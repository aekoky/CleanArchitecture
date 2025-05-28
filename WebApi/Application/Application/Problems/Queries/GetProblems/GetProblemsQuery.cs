using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.DTOs;
using Microsoft.Extensions.Caching.Distributed;
using CleanArchitecture.Application.Common;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

namespace CleanArchitecture.Application.Application.Problems.Queries.GetProblems;

public record GetProblemsQuery : IRequest<ProblemsDto>;

public class GetProblemsQueryHandler(IApplicationDbContext dbContext, IMapper mapper, IDistributedCache cache) : IRequestHandler<GetProblemsQuery, ProblemsDto>
{
    public async Task<ProblemsDto> Handle(GetProblemsQuery request, CancellationToken cancellationToken)
    {
        var problemsList = cache.GetAutoJson<ProblemsDto>("problemsList");
        if (problemsList is not null)
            return problemsList;

        var problemCatalogs = await dbContext.ProblemCatalogs
            .AsNoTracking()
            .OrderBy(problem => problem.Name)
            .ThenByDescending(problem => problem.Created)
            .ProjectTo<ProblemCatalogDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var problemCategories = await dbContext.ProblemCategories
            .AsNoTracking()
            .OrderBy(problem => problem.Name)
            .ThenByDescending(problem => problem.Created)
            .ProjectTo<ProblemCategoryDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var problems = await dbContext.Problems
            .AsNoTracking()
            .OrderBy(problem => problem.Name)
            .ThenByDescending(problem => problem.Created)
            .ProjectTo<ProblemDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        problemsList = new ProblemsDto(problemCatalogs, problemCategories, problems);
        cache.SetAutoJson("problemsList", problemsList);

        return problemsList;
    }
}

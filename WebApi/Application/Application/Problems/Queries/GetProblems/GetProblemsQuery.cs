using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.DTOs;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Application.Problems.Queries.GetProblems;

public record GetProblemsQuery : IRequest<ProblemsDto>;

public class GetProblemsQueryHandler(IApplicationDbContext dbContext, IMapper mapper) : IRequestHandler<GetProblemsQuery, ProblemsDto>
{
    public async Task<ProblemsDto> Handle(GetProblemsQuery request, CancellationToken cancellationToken)
    {
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

        return new ProblemsDto(problemCatalogs, problemCategories, problems);
    }
}

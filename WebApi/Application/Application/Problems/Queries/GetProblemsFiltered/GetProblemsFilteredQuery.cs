using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.DTOs;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Application.Problems.Queries.GetProblemsFiltered;

public record GetProblemsFilteredQuery : IRequest<List<ProblemDto>>
{
    public string? Keyword { get; set; }

    public int? ProblemCategoryId { get; init; }
}

public class GetProblemsFilteredQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetProblemsFilteredQuery, List<ProblemDto>>
{
    public async Task<List<ProblemDto>> Handle(GetProblemsFilteredQuery request, CancellationToken cancellationToken)
    {
        var problems = context.Problems
            .AsNoTracking();

        if (!string.IsNullOrEmpty(request.Keyword))
            problems = problems.Where(problem =>
            problem.Name.Contains(request.Keyword) ||
            (!string.IsNullOrEmpty(problem.Description) && problem.Description.Contains(request.Keyword)));

        if (request.ProblemCategoryId.HasValue)
            problems = problems.Where(problem => problem.ProblemCategoryId == request.ProblemCategoryId);

        return await problems
             .OrderBy(problem => problem.Name).ThenByDescending(problem => problem.Created)
             .ProjectTo<ProblemDto>(mapper.ConfigurationProvider)
             .ToListAsync(cancellationToken);
    }
}

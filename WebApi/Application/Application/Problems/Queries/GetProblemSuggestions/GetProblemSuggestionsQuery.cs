using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.DTOs;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Application.Problems.Queries.GetProblemSuggestions;

public record GetProblemSuggestionsQuery : IRequest<ICollection<ProblemDto>>
{
    public string? Keyword { get; set; }

    public int? ProblemCategoryId { get; init; }

    public List<int> IncludedProblems { get; set; } = [];
}

public class GetProblemSuggestionQueryHandler(IApplicationDbContext dbContext, IMapper mapper) : IRequestHandler<GetProblemSuggestionsQuery, ICollection<ProblemDto>>
{
    public async Task<ICollection<ProblemDto>> Handle(GetProblemSuggestionsQuery request, CancellationToken cancellationToken)
    {
        var problems = dbContext.Problems
            .AsNoTracking();

        if (!string.IsNullOrEmpty(request.Keyword))
            problems = problems.Where(problem =>
            problem.Name.Contains(request.Keyword) ||
            (!string.IsNullOrEmpty(problem.Description) && problem.Description.Contains(request.Keyword)));
        
        if (request.ProblemCategoryId.HasValue)
            problems = problems.Where(problem => problem.ProblemCategoryId == request.ProblemCategoryId);

        var problemsSuggestions = await problems.Take(20).ToListAsync(cancellationToken);
        var problemsSuggestionsIds = problemsSuggestions.Select(problem => problem.Id).ToList();

        if (request.IncludedProblems.Count != 0)
            problemsSuggestions.AddRange(dbContext.Problems.Where(problem => request.IncludedProblems.Contains(problem.Id) && !problemsSuggestionsIds.Contains(problem.Id)).AsNoTracking());

        return mapper.Map<ICollection<ProblemDto>>(problemsSuggestions);
    }
}

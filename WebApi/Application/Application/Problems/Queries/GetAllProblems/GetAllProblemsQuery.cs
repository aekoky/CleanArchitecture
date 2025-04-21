using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.DTOs;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Application.Problems.Queries.GetAllProblems;

public record GetAllProblemsQuery : IRequest<List<ProblemDto>>;

public class GetAllProblemsQueryHandler(IApplicationDbContext dbContext, IMapper mapper) : IRequestHandler<GetAllProblemsQuery, List<ProblemDto>>
{
    public async Task<List<ProblemDto>> Handle(GetAllProblemsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Problems
            .AsNoTracking()
            .OrderBy(problem => problem.Name)
            .ThenByDescending(problem => problem.Created)
            .ProjectTo<ProblemDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

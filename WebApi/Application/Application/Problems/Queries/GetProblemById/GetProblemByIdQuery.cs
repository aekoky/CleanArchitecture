using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.DTOs;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Application.Problems.Queries.GetProblemById;

public record GetProblemByIdQuery : IRequest<ProblemDto>
{
    public int Id { get; init; }
}

public class GetProblemByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) : IRequestHandler<GetProblemByIdQuery, ProblemDto>
{
    public async Task<ProblemDto> Handle(GetProblemByIdQuery request, CancellationToken cancellationToken)
    {
        var problem = await dbContext.Problems
            .Include(problem => problem.ProblemCategory)
            .ThenInclude(problemCategory => problemCategory!.ProblemCatalog)
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Problem), request.Id);

        return mapper.Map<ProblemDto>(problem);
    }
}

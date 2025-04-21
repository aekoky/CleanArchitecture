using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.DTOs;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Application.ProblemCategories.Queries.GetProblemCategoryById;

public record GetProblemCategoryByIdQuery : IRequest<ProblemCategoryDto>
{
    public int Id { get; init; }
}

public class GetProblemCategoryByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) : IRequestHandler<GetProblemCategoryByIdQuery, ProblemCategoryDto>
{
    public async Task<ProblemCategoryDto> Handle(GetProblemCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var problemCategory = await dbContext.ProblemCategories
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(ProblemCategory), request.Id);

        return mapper.Map<ProblemCategoryDto>(problemCategory);
    }
}

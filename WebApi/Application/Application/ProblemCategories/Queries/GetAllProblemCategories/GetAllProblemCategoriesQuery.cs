using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.DTOs;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Application.ProblemCategories.Queries.GetAllProblemCategories;

public record GetAllProblemCategoriesQuery : IRequest<List<ProblemCategoryDto>>;

public class GetAllProblemCategoriesQueryHandler(IApplicationDbContext dbContext, IMapper mapper) : IRequestHandler<GetAllProblemCategoriesQuery, List<ProblemCategoryDto>>
{
    public async Task<List<ProblemCategoryDto>> Handle(GetAllProblemCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.ProblemCategories
            .AsNoTracking()
            .OrderBy(problemCategory => problemCategory.Name)
            .ThenByDescending(problemCategory => problemCategory.Created)
            .ProjectTo<ProblemCategoryDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

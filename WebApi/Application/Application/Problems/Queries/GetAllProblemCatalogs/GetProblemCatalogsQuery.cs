using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.DTOs;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Queries.GetAllProblemCatalogs;

public record GetProblemCatalogsQuery : IRequest<ProblemCategoriesDto>;

public class GetProblemCatalogsQueryHandler(IApplicationDbContext dbContext) : IRequestHandler<GetProblemCatalogsQuery, ProblemCategoriesDto>
{
    public async Task<ProblemCategoriesDto> Handle(GetProblemCatalogsQuery request, CancellationToken cancellationToken)
    {
        var problemCategoriesDto = new ProblemCategoriesDto();
        var problemCatalogs = await dbContext.ProblemCatalogs
            .AsNoTracking()
            .Select(problemCatalog => new ProblemCatalogDto
            {
                Id = problemCatalog.Id,
                Name = problemCatalog.Name,
                Description = problemCatalog.Description,
            })
            .ToListAsync(cancellationToken);

        var problemCategories = await dbContext.ProblemCategories
            .AsNoTracking()
            .Select(problemCategory => new ProblemCategoryDto
            {
                Id = problemCategory.Id,
                Name = problemCategory.Name,
                Description = problemCategory.Description,
                ProblemCatalogId = problemCategory.ProblemCatalogId
            })
            .ToListAsync(cancellationToken);
        foreach (var catalog in problemCatalogs)
        {
            foreach (var category in problemCategories)
            {
                if (!category.ProblemCatalogId.HasValue)
                    problemCategoriesDto.ProblemCategories.Add(category);
                else if (category.ProblemCatalogId == catalog.Id)
                    catalog.Categories.Add(category);
            }
            problemCategoriesDto.ProblemCatalogs.Add(catalog);
        }

        return problemCategoriesDto;
    }
}

namespace CleanArchitecture.Application.Common.DTOs;
public class ProblemCategoriesDto 
{
    public List<ProblemCatalogDto> ProblemCatalogs { get; private set; } = [];
    public List<ProblemCategoryDto> ProblemCategories { get; private set; } = [];
}
namespace CleanArchitecture.Application.Common.DTOs;

public class ProblemsDto
{
    public ProblemsDto(List<ProblemCatalogDto> problemCatalogs, List<ProblemCategoryDto> problemCategories, List<ProblemDto> problems)
    {
        ProblemCatalogs = problemCatalogs;
        ProblemCategories = problemCategories;
        Problems = problems;
    }

    public List<ProblemCatalogDto> ProblemCatalogs { get; private set; } = [];
    public List<ProblemCategoryDto> ProblemCategories { get; private set; } = [];
    public List<ProblemDto> Problems { get; private set; } = [];
}
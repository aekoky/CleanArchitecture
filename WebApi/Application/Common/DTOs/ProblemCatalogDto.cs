using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.DTOs;

public class ProblemCatalogDto : IMapFrom<ProblemCatalog>
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public List<ProblemCategoryDto> Categories { get; private set; } = [];

}
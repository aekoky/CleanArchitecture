using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.DTOs;

public class ProblemCategoryDto : IMapFrom<ProblemCategory>
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public int? ProblemCatalogId { get; set; }

    public List<ProblemDto> Problems { get; private set; } = [];
}
using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.DTOs;

public class ProblemCatalogDto : IMapFrom<ProblemCatalog>
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public int CategoriesCount { get; private set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProblemCatalog, ProblemCatalogDto>()
            .ForMember(e => e.CategoriesCount, m => m.MapFrom(e => e.ProblemCategories.Count()));
    }
}
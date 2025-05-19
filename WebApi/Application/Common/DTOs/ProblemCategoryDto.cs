using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.DTOs;

public class ProblemCategoryDto : IMapFrom<ProblemCategory>
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public int? ProblemCatalogId { get; set; }

    public int ProblemsCount { get; private set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProblemCategory, ProblemCategoryDto>()
            .ForMember(e => e.ProblemsCount, m => m.MapFrom(e => e.Problems.Count()));
    }
}
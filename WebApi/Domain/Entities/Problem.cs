namespace CleanArchitecture.Domain.Entities;

public class Problem : BaseAuditableEntity
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public int? ProblemCategoryId { get; set; }

    public ProblemCategory? ProblemCategory { get; set; }

}

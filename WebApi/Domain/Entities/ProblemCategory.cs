namespace CleanArchitecture.Domain.Entities;

public class ProblemCategory : BaseAuditableEntity
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public int? ProblemCatalogId { get; set; }

    public virtual ProblemCatalog? ProblemCatalog { get; set; }
}

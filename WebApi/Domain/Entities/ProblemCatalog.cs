namespace CleanArchitecture.Domain.Entities;

public class ProblemCatalog : BaseAuditableEntity
{
    public required string Name { get; set; }

    public string? Description { get; set; }
}

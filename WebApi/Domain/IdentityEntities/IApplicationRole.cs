namespace CleanArchitecture.Domain.IdentityEntities;

public interface IApplicationRole
{
    public string Id { get; set; }

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }
}

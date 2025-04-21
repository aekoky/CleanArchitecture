namespace CleanArchitecture.Domain.IdentityEntities;

public interface IApplicationUser
{
    public string Id { get; set; }

    public string TenantId { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public bool EmailConfirmed { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public string? SecurityStamp { get; set; }

    public List<string> Permissions { get; set; }
}

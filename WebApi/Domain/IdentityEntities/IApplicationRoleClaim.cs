using System.Security.Claims;

namespace CleanArchitecture.Domain.IdentityEntities;

public interface IApplicationRoleClaim
{
    public int Id { get; set; }

    public string RoleId { get; set; }

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public Claim ToClaim();

    public void InitializeFromClaim(Claim? other);
}

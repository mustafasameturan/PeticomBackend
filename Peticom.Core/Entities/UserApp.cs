using Microsoft.AspNetCore.Identity;

namespace Peticom.Core.Entities;

public class UserApp : IdentityUser
{
    public string? FullName { get; set; }
    public string? City { get; set; }
    public string? VerificationCode { get; set; }
    public PeticomerBadge PeticomerBadge { get; set; }
    public ICollection<PetIdentity> PetIdentities { get; set; }
    public ICollection<Ad> Ads { get; set; }

}
using Microsoft.AspNetCore.Identity;

namespace Peticom.Core.Entities;

public class UserApp : IdentityUser
{
    public string? FullName { get; set; }
    public string? City { get; set; }
    public string? VerificationCode { get; set; }
    public DateTime? BirthDate { get; set; }
    
    public string? ImageUrl { get; set; }
    public string? ResetPasswordVerificationCode { get; set; }
    public PeticomerBadge PeticomerBadge { get; set; }
    public ICollection<PetIdentity> PetIdentities { get; set; }
    public ICollection<Ad> Ads { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}
using Peticom.Core.Entities;
using Peticom.Core.Enums;

namespace Peticom.Core.Models;

public class PetIdentityModel
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string PetBreed { get; set; }
    public string Name { get; set; }
    public Pet Type { get; set; }
    public string Color { get; set; }
    public DateTime? BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string Food { get; set; }
    public string? PetLitter { get; set; }
    public DateTime LastInsDate { get; set; }
}
using System.Text.Json.Serialization;
using Peticom.Core.Enums;

namespace Peticom.Core.Entities;

public class PetIdentity : BaseEntity
{
    public string UserId { get; set; }
    public string? Name { get; set; }
    public string? PetBreed { get; set; }
    public Pet Type { get; set; }
    public string Color { get; set; }
    public DateTime? BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string Food { get; set; }
    public string? PetLitter { get; set; }
    public DateTime LastInsDate { get; set; }
    public UserApp UserApp { get; set; }
    public ICollection<PetDisease> PetDiseases { get; set; }
    public ICollection<PetVaccine> PetVaccines { get; set; }
    
}
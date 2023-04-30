using Core.Enums;

namespace Core.Entities;

public class PetIdentity : BaseEntity
{
    public string UserId { get; set; }
    public string Type { get; set; }
    public string Color { get; set; }
    public DateTime? BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string Food { get; set; }
    public string? PetLitter { get; set; }
    public DateTime LastInsDate { get; set; }
}
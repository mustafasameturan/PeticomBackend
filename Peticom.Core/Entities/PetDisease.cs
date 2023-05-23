using System.Text.Json.Serialization;

namespace Peticom.Core.Entities;

public class PetDisease : BaseEntity
{
    public Guid PetId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public PetIdentity PetIdentity { get; set; }
}
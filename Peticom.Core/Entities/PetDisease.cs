namespace Core.Entities;

public class PetDisease : BaseEntity
{
    public Guid PetId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
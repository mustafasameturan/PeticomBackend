namespace Peticom.Core.Models.PetDisease;

public class PetDiseaseModel
{
    public Guid Id { get; set; }
    public Guid PetId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
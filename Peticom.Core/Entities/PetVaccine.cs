namespace Peticom.Core.Entities;

public class PetVaccine : BaseEntity
{
    public Guid PetId { get; set; }
    public string Name { get; set; }
    public DateTime VaccineDate { get; set; }
    public int Period { get; set; }
    public PetIdentity PetIdentity { get; set; }
}
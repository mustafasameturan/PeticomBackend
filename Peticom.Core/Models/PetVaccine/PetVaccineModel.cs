namespace Peticom.Core.Models.PetVaccine;

public class PetVaccineModel 
{
    public Guid PetId { get; set; }
    public string Name { get; set; }
    public DateTime VaccineDate { get; set; }
    public int Period { get; set; }
}
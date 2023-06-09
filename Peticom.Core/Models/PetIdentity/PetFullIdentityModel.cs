using Peticom.Core.Enums;
using Peticom.Core.Models.PetDisease;
using Peticom.Core.Models.PetVaccine;

namespace Peticom.Core.Models;

public class PetFullIdentityModel
{
    public Guid PetId { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Color { get; set; }
    public DateTime? BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string Food { get; set; }
    public string? PetLitter { get; set; }
    public DateTime LastInsDate { get; set; }
    public List<PetDiseaseModel> PetDiseases { get; set; }
    public List<PetVaccineModel> PetVaccines { get; set; }
}
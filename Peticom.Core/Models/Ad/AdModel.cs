using Peticom.Core.Enums;
using Peticom.Core.Entities;

namespace Peticom.Core.Models;

public class AdModel
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public int CityId { get; set; }
    public string Slogan { get; set; }
    public string About { get; set; }
    public double Price { get; set; }
    public Pet? PetType { get; set; }
    public ICollection<Peticom.Core.Entities.Star> Stars { get; set; }
    public DateTime CreatedDate { get; set; }
}
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Peticom.Core.Enums;

namespace Peticom.Core.Entities;

public class Ad : BaseEntity
{
    public string UserId { get; set; }
    public string Slogan { get; set; }
    public string About { get; set; }
    public double Price { get; set; }
    public int CityId { get; set; }
    public Pet? PetType { get; set; }
    public UserApp UserApp { get; set; }
    public City City{ get; set; }
    public ICollection<Star> Stars { get; set; }
    public ICollection<Ad> Ads { get; set; }
}
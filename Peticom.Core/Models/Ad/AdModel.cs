namespace Peticom.Core.Models;

public class AdModel
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public int CityId { get; set; }
    public string Slogan { get; set; }
    public string About { get; set; }
    public double Price { get; set; }
    public DateTime CreatedDate { get; set; }
}
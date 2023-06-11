using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Peticom.Core.Models.User;

public class UserAppModel
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? ImageUrl { get; set; }
}
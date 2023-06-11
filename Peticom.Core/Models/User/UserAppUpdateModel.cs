namespace Peticom.Core.Models.User;

public class UserAppUpdateModel
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string City { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public DateTime? BirthDate { get; set; }
}
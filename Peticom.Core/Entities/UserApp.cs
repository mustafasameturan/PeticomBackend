using Microsoft.AspNetCore.Identity;

namespace Peticom.Core.Entities;

public class UserApp : IdentityUser
{
    public string FullName { get; set; }
    public string City { get; set; }
}
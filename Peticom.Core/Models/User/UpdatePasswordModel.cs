namespace Peticom.Core.Models.User;

public class UpdatePasswordModel
{
    public string UserId { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public string NewPasswordAgain { get; set; }
}
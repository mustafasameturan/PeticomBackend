namespace Peticom.Core.Models.User;

public class ResetPasswordModel
{
    public string Email { get; set; }
    public string NewPassword { get; set; }
    public string NewPasswordAgain { get; set; }
}
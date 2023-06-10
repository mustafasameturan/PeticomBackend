namespace Peticom.Core.Models.User;

public class ConfirmVerificationCodeResetPasswordModel
{
    public string Email { get; set; }
    public string VerificationCode { get; set; }
}
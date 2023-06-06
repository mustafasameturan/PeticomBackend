namespace Peticom.Core.Models.User;

public class ConfirmVerificationCodeModel
{
    public string UserId { get; set; }
    public string VerificationCode { get; set; }
}
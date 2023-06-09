using Microsoft.AspNetCore.Identity;

namespace Peticom.Service.Constants;

public class ErrorDescriber : IdentityErrorDescriber 
{
    public override IdentityError DuplicateUserName(string userName)
    {
        return new() { Code = "DuplicateUserName", Description = Messages.DUPLICATE_USER_NAME };
    }

    public override IdentityError DuplicateEmail(string email)
    {
        return new() { Code = "DuplicateEmail", Description = Messages.DUPLICATE_EMAİL };
    }

    public override IdentityError PasswordTooShort(int length)
    {
        return new() { Code = "PasswordTooShort", Description = Messages.PASSWORD_TOO_SHORT };
    }

    public override IdentityError PasswordRequiresLower()
    {
        return new() { Code = "PasswordRequiresLower", Description = Messages.PASSWORD_REQUIRES_LOWER };
    }
}
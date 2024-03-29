using Peticom.Core.Models;
using Peticom.Core.Models.Login;
using Peticom.Core.Models.Register;
using Peticom.Core.Models.Token;
using Peticom.Core.Models.User;
using Peticom.Core.Responses;

namespace Peticom.Core.Services;

public interface IUserService
{
    Task<Response<TokenModel>> LoginAsync(LoginModel loginModel);
    Task<Response<UserAppModel>> RegisterAsync(RegisterModel registerModel);
    Task<Response<UpdatePasswordModel>> UpdatePasswordAsync(UpdatePasswordModel updatePasswordModel);
    Task<Response<NoDataModel>> SendVerificationCodeForResetPasswordAsync(string email);

    Task<Response<NoDataModel>> ConfirmVerificationCodeForResetPasswordAsync(ConfirmVerificationCodeResetPasswordModel model);
    Task<Response<NoDataModel>> ResetPasswordAsync(ResetPasswordModel resetPasswordModel);
    Task<Response<NoDataModel>> SendVerificationCode(string userId);

    Task<Response<NoDataModel>> ConfirmVerificationCode(ConfirmVerificationCodeModel confirmVerificationCodeModel);

    Task<Response<List<UserAppModel>>> GetAllUsersAsync();

    Task<Response<List<UserAppModel>>> GetUsersByRoleAsync(string role);

    Task<Response<UserAppModel>> GetUserByIdAsync(string userId);

    Task<Response<UserAppUpdateModel>> UpdateUserAsync(UserAppUpdateModel userAppUpdateModel);
}
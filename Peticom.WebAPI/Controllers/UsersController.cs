using Microsoft.AspNetCore.Mvc;
using Peticom.Core.Models.Login;
using Peticom.Core.Models.Register;
using Peticom.Core.Models.User;
using Peticom.Core.Services;

namespace Peticom.WebAPI.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : BaseController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _userService.GetAllUsersAsync());
    }
    
    [HttpGet("getByUserId")]
    public async Task<IActionResult> GetByUserId(string userId)
    {
        return CreateActionResult(await _userService.GetUserByIdAsync(userId));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterModel registerModel)
    {
        return CreateActionResult(await _userService.RegisterAsync(registerModel));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        return CreateActionResult(await _userService.LoginAsync(loginModel));
    }
    
    [HttpPost("updatePassword")]
    public async Task<IActionResult> UpdatePassword(UpdatePasswordModel updatePasswordModel)
    {
        return CreateActionResult(await _userService.UpdatePasswordAsync(updatePasswordModel));
    }
    
    [HttpPost("sendVerificationCodeForResetPassword")]
    public async Task<IActionResult> SendVerficaitionCodeForResetPassword([FromBody] string email)
    {
        return CreateActionResult(await _userService.SendVerificationCodeForResetPasswordAsync(email));
    }

    [HttpPost("confirmVerificationCodeForResetPassword")]
    public async Task<IActionResult> ConfirmVerficaitionCodeForResetPassword(ConfirmVerificationCodeResetPasswordModel model)
    {
        return CreateActionResult(await _userService.ConfirmVerificationCodeForResetPasswordAsync(model));
    }

    [HttpPost("resetPassword")]
    public async Task<IActionResult> ResetPasswordAsync(ResetPasswordModel model)
    {
        return CreateActionResult(await _userService.ResetPasswordAsync(model));
    }
    
    [HttpPost("sendVerificationCode/{userId}")]
    public async Task<IActionResult> SendVerificationCode(string userId)
    {
        return CreateActionResult(await _userService.SendVerificationCode(userId));
    }

    [HttpPost("confirmVerificationCode")]
    public async Task<IActionResult> ConfirmVerificationCode(ConfirmVerificationCodeModel model)
    {
        return CreateActionResult(await _userService.ConfirmVerificationCode(model));
    }

    [HttpPost("updateUser")]
    public async Task<IActionResult> UpdateUser(UserAppUpdateModel userAppUpdateModel)
    {
        return CreateActionResult(await _userService.UpdateUserAsync(userAppUpdateModel));
    }
}
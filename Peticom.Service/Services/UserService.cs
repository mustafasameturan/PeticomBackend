using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Peticom.Core.Domain;
using Peticom.Core.Entities;
using Peticom.Core.Models;
using Peticom.Core.Models.Login;
using Peticom.Core.Models.Register;
using Peticom.Core.Models.Token;
using Peticom.Core.Models.User;
using Peticom.Core.Responses;
using Peticom.Core.Services;
using Peticom.Service.Constants;

namespace Peticom.Service.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly UserManager<UserApp> _userManager;
    private readonly ITokenService _tokenService;
    private readonly IEmailService _emailService;

    public UserService(UserManager<UserApp> userManager, IMapper mapper, IEmailService emailService, IConfiguration configuration,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _emailService = emailService;
        _tokenService = tokenService;
        _configuration = configuration;
    }

    /// <summary>
    /// This method used for login.
    /// </summary>
    /// <param name="loginModel"></param>
    /// <returns></returns>
    public async Task<Response<TokenModel>> LoginAsync(LoginModel loginModel)
    {
        if (loginModel == null) throw new ArgumentNullException(nameof(loginModel));

        var user = await _userManager.FindByEmailAsync(loginModel.Email);

        if (user == null) return Response<TokenModel>.Fail(Messages.USER_NOT_FOUND, 404, true);

        if (!await _userManager.CheckPasswordAsync(user, loginModel.Password))
        {
            return Response<TokenModel>.Fail(Messages.PASSWORD_WRONG, 400, true);
        }
        
        var userRoles = await _userManager.GetRolesAsync(user);
        var token = _tokenService.CreateToken(user, userRoles);

        return Response<TokenModel>.Success(token, 200);
    }

    /// <summary>
    /// This method used for register users.
    /// </summary>
    /// <param name="registerModel"></param>
    /// <returns></returns>
    public async Task<Response<UserAppModel>> RegisterAsync(RegisterModel registerModel)
    {
        var user = new UserApp
        {
            Email = registerModel.Email, 
            FullName = registerModel.FullName, 
            PhoneNumber = registerModel.PhoneNumber,
            UserName = registerModel.Email
        };
        
        var result = await _userManager.CreateAsync(user, registerModel.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description).ToList();
            
            return Response<UserAppModel>.Fail(new ErrorModel(errors), 400);
        }
        
        await _userManager.AddToRoleAsync(user, Roles.User);
        return Response<UserAppModel>.Success(_mapper.Map<UserAppModel>(user), 200);
    }

    /// <summary>
    /// This method used for update password.
    /// </summary>
    /// <param name="updatePasswordModel"></param>
    /// <returns></returns>
    public async Task<Response<UpdatePasswordModel>> UpdatePasswordAsync(UpdatePasswordModel updatePasswordModel)
    {
        var user = await _userManager.FindByIdAsync(updatePasswordModel.UserId);
        
        if (user is null)
        {
            return Response<UpdatePasswordModel>.Fail(Messages.USER_NOT_FOUND, 404, true);
        }

        var signInResult = await _userManager.CheckPasswordAsync(user, updatePasswordModel.CurrentPassword);

        if (!signInResult)
        {
            return Response<UpdatePasswordModel>.Fail(Messages.CURRENT_PASSWORD_WRONG, 400, true);
        }

        if (updatePasswordModel.NewPassword != updatePasswordModel.NewPasswordAgain)
        {
            return Response<UpdatePasswordModel>.Fail(Messages.PASSWORDS_NOT_MATCH, 400, true);
        }

        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, resetToken, updatePasswordModel.NewPassword);

        if (!result.Succeeded)
        {
            return Response<UpdatePasswordModel>.Fail(Messages.PASSWORD_UPDATE_ERROR, 400, true);
        }

        return Response<UpdatePasswordModel>.Success(200);
    }

    /// <summary>
    /// This code send verification code to user.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<Response<NoDataModel>> SendVerificationCode(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var verificationCode = GenerateCode();
        
        //update user fields
        user.VerificationCode = verificationCode;

        var result = await _userManager.UpdateAsync(user);
        //update user fields

        if (result.Succeeded)
        {
            _emailService.SendEmail(
                _configuration[Settings.SenderEmail], 
                user.Email, 
                "Doğrulama Kodu", 
                "Doğrulama Kodunuz: " + verificationCode
            );

            return Response<NoDataModel>.Success("Verification code was sended.", 200);   
        }
        
        var errors = result.Errors.Select(e => e.Description).ToList();
        return Response<NoDataModel>.Fail(new ErrorModel(errors), 400);
    }

    /// <summary>
    /// This method confirm the code of sended to user.
    /// </summary>
    /// <param name="confirmVerificationCodeModel"></param>
    /// <returns></returns>
    public async Task<Response<NoDataModel>> ConfirmVerificationCode(ConfirmVerificationCodeModel confirmVerificationCodeModel)
    {
        var user = await _userManager.FindByIdAsync(confirmVerificationCodeModel.UserId);

        if (user is null)
        {
            return Response<NoDataModel>.Fail("User is not found!", 404, true);
        }

        if (user.VerificationCode != confirmVerificationCodeModel.VerificationCode)
        {
            return Response<NoDataModel>.Fail("Verification codes not match!", 400, true);
        }
        
        //Update user fields
        user.VerificationCode = null;
        user.EmailConfirmed = true;
        //Update user fields
        
        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            _emailService.SendEmail(
                _configuration[Settings.SenderEmail],
                user.Email,
                "Hesabınız Doğrulandı",
                "Hesabınız başarıyla doğrulandı!"
            );
            return Response<NoDataModel>.Success("User is successfully verificated!", 200);
        }
        
        var errors = result.Errors.Select(e => e.Description).ToList();
        return Response<NoDataModel>.Fail(new ErrorModel(errors), 400);
    }

    /// <summary>
    /// This method gets all users asynchronously.
    /// </summary>
    /// <returns></returns>
    public async Task<Response<List<UserAppModel>>> GetAllUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync();

        if (users.Count == 0)
        {
            return Response<List<UserAppModel>>.Fail("Users not found.", 404, true);
        }
    
        return Response<List<UserAppModel>>.Success(_mapper.Map<List<UserAppModel>>(users), 200);
    }

    /// <summary>
    /// This method get user by id async.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<Response<UserAppModel>> GetUserByIdAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
        {
            return Response<UserAppModel>.Fail("User is not found.", 404, true);
        }

        return Response<UserAppModel>.Success(_mapper.Map<UserAppModel>(user), 200);
    }

    /// <summary>
    /// This method update the user. 
    /// </summary>
    /// <param name="userAppUpdateModel"></param>
    /// <returns></returns>
    public async Task<Response<UserAppUpdateModel>> UpdateUserAsync(UserAppUpdateModel userAppUpdateModel)
    {
        var user = await _userManager.FindByIdAsync(userAppUpdateModel.Id);

        if (user is null)
        {
            return Response<UserAppUpdateModel>.Fail("User is not found.", 404, true);
        }
        
        //Update user fields
        user.FullName = userAppUpdateModel.FullName;
        user.City = userAppUpdateModel.City;
        user.UserName = userAppUpdateModel.UserName;
        //Update user fields

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            return Response<UserAppUpdateModel>.Success("User is successfully updated!", 200);
        }
        
        var errors = result.Errors.Select(e => e.Description).ToList();
        return Response<UserAppUpdateModel>.Fail(new ErrorModel(errors), 400);
        
    }


    private static string GenerateCode()
    {
        Random random = new Random();
        StringBuilder codeBuilder = new StringBuilder();

        for (int i = 0; i < 6; i++)
        {
            int randomNumber = random.Next(0, 10);
            codeBuilder.Append(randomNumber);
        }

        return codeBuilder.ToString();
    }
}
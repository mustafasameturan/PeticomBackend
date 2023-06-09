using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Peticom.Core.Domain;
using Peticom.Core.Entities;
using Peticom.Core.Models.Token;
using Peticom.Core.Services;

namespace Peticom.Service.Services;

public class TokenService : ITokenService
{
    private readonly UserManager<UserApp> _userManager;
    private readonly TokenSettings _tokenSettings;

    public TokenService(UserManager<UserApp> userManager, IOptions<TokenSettings> options)
    {
        _userManager = userManager;
        _tokenSettings = options.Value;
    }

    /// <summary>
    /// This method used for create token.
    /// </summary>
    /// <param name="userApp"></param>
    /// <returns></returns>
    public TokenModel CreateToken(UserApp userApp, IList<string> userRoles)
    {
        var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenSettings.Expiration);
        var securityKey = SignService.GetSymmetricSecurityKey(_tokenSettings.SecurityKey);
        
        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: _tokenSettings.Issuer,
            expires: accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: GetClaims(userApp, userRoles),
            signingCredentials: signingCredentials);

        var handler = new JwtSecurityTokenHandler();

        var token = handler.WriteToken(jwtSecurityToken);

        var tokenModel = new TokenModel
        {
            Token = token,
            TokenExpiration = accessTokenExpiration,
        };

        return tokenModel;
    }

    private IEnumerable<Claim> GetClaims(UserApp userApp, IList<string> userRoles)
    {
        var claims = new List<Claim>
        {
            new Claim("UserId", userApp.Id),
            new Claim("UserEmail", userApp.Email),
            new Claim("UserName", userApp.UserName),
            new Claim("IsUserVerificated", userApp.EmailConfirmed.ToString()),
            new Claim("UserRoles", string.Join(",", userRoles))
        };
        
        return claims;
    }
}
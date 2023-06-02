using Peticom.Core.Entities;
using Peticom.Core.Models.Token;

namespace Peticom.Core.Services;

public interface ITokenService
{
    TokenModel CreateToken(UserApp userApp);
}
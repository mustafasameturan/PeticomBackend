namespace Core.Models;

public class TokenModel
{
    public string AccessToken { get; set; }
    public DateTime AccessTokenExpiration { get; set; }
}
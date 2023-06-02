namespace Peticom.Core.Domain;

public class TokenSettings
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public int Expiration { get; set; }
    public string SecurityKey { get; set; }
}
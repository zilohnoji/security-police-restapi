using System.Security.Cryptography;

namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class RefreshToken : BaseEntity
{
    public string Token { get; private set; } = "";
    public DateTime ExpiryTime { get; private set; } = DateTime.UtcNow;
    public User User { get; private set; } = User.Empty;

    private RefreshToken()
    {
    }

    public RefreshToken(string token, DateTime expiryTime)
    {
        Token = token;
        ExpiryTime = expiryTime;
    }

    public static RefreshToken Of(int refreshTokenLength)
    {
        var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(refreshTokenLength));
        return new RefreshToken(token, DateTime.UtcNow.AddDays(7));
    }
}
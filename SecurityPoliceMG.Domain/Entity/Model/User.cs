namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class User : BaseEntity
{
    public string Email { get; private set; } = string.Empty;

    public string Password { get; private set; } = string.Empty;

    public string? RefreshToken { get; private set; }

    public DateTime? RefreshTokenExpiryTime { get; private set; } = DateTime.Now;

    public Person Person { get; private set; } = Person.Empty;

    public static readonly User Empty = new User();

    private User()
    {
    }

    private User(string email, string password, string refreshToken, DateTime? refreshTokenExpiryTime)
    {
        Email = email;
        Password = password;
        RefreshToken = refreshToken;
        RefreshTokenExpiryTime = refreshTokenExpiryTime;
    }

    public static User Of(string email, string password, DateTime? refreshTokenExpiryTime, string refreshToken = "")
    {
        return new User(email, password, refreshToken, refreshTokenExpiryTime);
    }

    public void DefineRefreshToken(string? refreshToken)
    {
        RefreshToken = refreshToken;
    }

    public void DefineRefreshToken(string? refreshToken, DateTime refreshTokenExpiryTime)
    {
        RefreshTokenExpiryTime = refreshTokenExpiryTime;
    }
}
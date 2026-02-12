namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class User : BaseEntity
{
    public string Email { get; private set; } = string.Empty;

    public string Password { get; private set; } = string.Empty;

    public Guid? RefreshTokenId { get; private set; }

    public RefreshToken? RefreshToken { get; private set; }

    public Person Person { get; private set; } = Person.Empty;

    public static readonly User Empty = new User();

    private User()
    {
    }

    private User(string email, string password, RefreshToken refreshToken)
    {
        Email = email;
        Password = password;
        RefreshToken = refreshToken;
    }

    public static User Of(string email, string password, RefreshToken refreshToken)
    {
        return new User(email, password, refreshToken);
    }

    public void RevokeRefreshToken()
    {
        RefreshToken = null;
    }
    
    public void DefineRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken = refreshToken;
    }
}
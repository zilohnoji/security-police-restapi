namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class User : BaseEntity
{
    public string Email { get; private set; }

    public string Password { get; private set; }

    public Guid? RefreshTokenId { get; private set; }

    public RefreshToken? RefreshToken { get; private set; }

    public Person? Person { get; private set; }

    public Guid EmailCodeConfirmationId { get; private set; }

    public EmailCodeConfirmation? EmailCodeConfirmation { get; private set; }

    public bool IsActive { get; private set; }

    private User()
    {
    }

    private User(string email, string password, RefreshToken refreshToken, EmailCodeConfirmation emailCodeConfirmation)
    {
        Email = email;
        Password = password;
        RefreshToken = refreshToken;
        EmailCodeConfirmation = emailCodeConfirmation;
    }

    public static User Of(string email, string password, EmailCodeConfirmation emailCode, RefreshToken refreshToken = null)
    {
        return new User(email, password, refreshToken, emailCode);
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
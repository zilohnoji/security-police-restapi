namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class User : BaseEntity
{
    public string Email { get; private set; } = string.Empty;

    public string Password { get; private set; } = string.Empty;

    public Person Person { get; private set; } = Person.Empty;

    public static readonly User Empty = new User();

    private User()
    {
    }

    private User(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public static User Of(string email, string password)
    {
        return new User(email, password);
    }
}
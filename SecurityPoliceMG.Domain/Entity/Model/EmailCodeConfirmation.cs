namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class EmailCodeConfirmation : BaseEntity
{
    public string Code { get; private set; }

    public DateTime ExpiryTime { get; private set; }

    public User User { get; private set; }

    private EmailCodeConfirmation()
    {
    }

    private EmailCodeConfirmation(string code, DateTime expiryTime)
    {
        Code = code;
        ExpiryTime = expiryTime;
    }

    public static EmailCodeConfirmation Of(DateTime expiryTime)
    {
        if (expiryTime < DateTime.UtcNow)
        {
            throw new ArgumentException("O código do email precisa ser maior que a data atual");
        }

        return new EmailCodeConfirmation(GenerateRandomString(8), expiryTime);
    }

    private static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Range(0, length)
            .Select(_ => chars[Random.Shared.Next(chars.Length)])
            .ToArray());
    }
}
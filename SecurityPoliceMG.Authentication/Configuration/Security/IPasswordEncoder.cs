namespace SecurityPoliceMG.Configuration.Security;

public interface IPasswordEncoder
{
    string Encode(string password);

    bool VerifyPassword(string password, string hashedPassword);
}
namespace SecurityPoliceMG.Contract;

public interface IPasswordEncoder
{
    string Encode(string password);

    bool MatchPassword(string password, string hashedPassword);
}
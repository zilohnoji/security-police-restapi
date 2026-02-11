using System.Security.Cryptography;
using System.Text;
using SecurityPoliceMG.Contract;

namespace SecurityPoliceMG.Utils;

public sealed class Sha256PasswordEncoder : IPasswordEncoder
{
    public string Encode(string password)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(password);
        byte[] hashedBytes = SHA256.HashData(buffer);
        return Convert.ToHexStringLower(hashedBytes);
    }

    public bool MatchPassword(string password, string hashedPassword)
    {
        var t = string.Equals(Encode(password), hashedPassword);
        var len = Encode(password).Length;
        var len2 = hashedPassword.Length;
        return t;
    }
}
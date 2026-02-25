using System.Security.Cryptography;
using System.Text;

namespace SecurityPoliceMG.Configuration.Security.Impl;

public sealed class Sha256PasswordEncoder : IPasswordEncoder
{
    public string Encode(string password)
    {
        return Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return string.Equals(Encode(password), hashedPassword);
    }
}
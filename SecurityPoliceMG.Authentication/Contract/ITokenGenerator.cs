using System.Security.Claims;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Contract;

public interface ITokenGenerator
{
    string GenerateAccessToken(User entity);

    string GetPrincipalFromExpiredAccessToken(string expiredAccessToken);
}
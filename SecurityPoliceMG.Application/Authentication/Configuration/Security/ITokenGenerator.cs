using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Configuration.Security;

public interface ITokenGenerator
{
    string GenerateAccessToken(User entity);

    string GetUsernameFromExpiredAccessToken(string expiredAccessToken);
}
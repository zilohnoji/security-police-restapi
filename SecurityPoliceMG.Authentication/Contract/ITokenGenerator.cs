using System.Security.Claims;

namespace SecurityPoliceMG.Contract;

public interface ITokenGenerator
{
    string GenerateAccessToken(IEnumerable<Claim> claims);

    string GenerateRefreshToken();

    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
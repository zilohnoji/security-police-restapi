using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SecurityPoliceMG.Contract;

namespace SecurityPoliceMG.Configuration.Security;

public class TokenConfig : ITokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public TokenConfig(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var securityToken = new JwtSecurityToken
        (
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var secretKey = Encoding.UTF8.GetBytes(_jwtSettings.Secret);

        var tokenParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKey)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var principal = tokenHandler.ValidateToken(token, tokenParameters, out SecurityToken securityToken);

            if (securityToken is JwtSecurityToken security)
            {
                if (security.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                        StringComparison.CurrentCultureIgnoreCase))
                {
                    return principal;
                }
            }

            throw new SecurityTokenException("Invalid token");
        }
        catch (Exception e)
        {
            throw new SecurityTokenException("Invalid token format");
        }
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using SecurityPoliceMG.Contract;
using SecurityPoliceMG.Domain.Entity.Model;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace SecurityPoliceMG.Configuration.Security;

public class TokenConfig : ITokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public TokenConfig(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateAccessToken(User entity)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            Subject = new ClaimsIdentity(
                [
                    new Claim(JwtRegisteredClaimNames.Sub, entity.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, entity.Email)
                ]
            ),
            SigningCredentials = signingCredentials,
            Expires = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes)
        };

        var handler = new JsonWebTokenHandler();

        return handler.CreateToken(tokenDescriptor);
    }

    public string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
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
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes)
        };

        var handler = new JsonWebTokenHandler();

        return handler.CreateToken(tokenDescriptor);
    }

    public string GetPrincipalFromExpiredAccessToken(string expiredAccessToken)
    {
        var secretKey = Encoding.UTF8.GetBytes(_jwtSettings.Secret);
        var tokenHandler = new JwtSecurityTokenHandler();

        if (!tokenHandler.CanReadToken(expiredAccessToken))
        {
            throw new ArgumentException("O token Jwt possui um formato inválido");
        }

        var tokenParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKey)
        };

        tokenHandler.ValidateToken(expiredAccessToken, tokenParameters, out var securityToken);

        if (securityToken.ValidTo > DateTime.UtcNow)
        {
            throw new ArgumentException("O token de acesso não está expirado!");
        }

        var security = (JwtSecurityToken)securityToken;
        var algorithm = security.Header.Alg;

        if (!algorithm.Equals(SecurityAlgorithms.HmacSha256, StringComparison.CurrentCultureIgnoreCase))
        {
            throw new ArgumentException("Algoritmo de segurança inválido!");
        }

        return security.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? throw new ArgumentException("Access token inválido!");;
    }
}
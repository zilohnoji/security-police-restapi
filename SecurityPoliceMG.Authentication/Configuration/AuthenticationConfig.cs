using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SecurityPoliceMG.Configuration.Security;

namespace SecurityPoliceMG.Configuration;

public static class AuthenticationConfig
{
    public static IServiceCollection ConfigureSecurity(this IServiceCollection service, IConfiguration configuration)
    {
        var jwtSettings = GetJwtSettings(configuration);
        var secretKey = Encoding.UTF8.GetBytes(jwtSettings.Secret);

        service
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey)
                };
            });

        service.AddAuthorization();

        return service;
    }

    private static JwtSettings GetJwtSettings(IConfiguration configuration)
    {
        return configuration.GetSection("JwtSettings").Get<JwtSettings>() ??
               throw new ArgumentException("As configurações do Token não foram definidas corretamente!");
    }
}
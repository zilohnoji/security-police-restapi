using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SecurityPoliceMG.Authentication.Configuration.Enum;
using SecurityPoliceMG.Configuration;

namespace SecurityPoliceMG.Authentication.Configuration;

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
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ClockSkew = TimeSpan.Zero
                };
            });

        service.AddAuthorization(options =>
        {
            options.AddPolicy(nameof(SecurityPolicy.ActiveUserOnly), policy => { policy.RequireClaim("is_active", "True"); });
        });

        return service;
    }

    private static JwtSettings GetJwtSettings(IConfiguration configuration)
    {
        return configuration.GetSection("JwtSettings").Get<JwtSettings>() ??
               throw new ArgumentException("As configurações do Token não foram definidas corretamente!");
    }
}
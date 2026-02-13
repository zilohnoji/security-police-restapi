using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
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

                jwtBearerOptions.Events = new JwtBearerEvents()
                {
                    OnChallenge = async context =>
                    {
                        context.HandleResponse();

                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";

                        var errorMessage = context.AuthenticateFailure switch
                        {
                            SecurityTokenExpiredException => "O seu access token está expirado",
                            _ => "Access token inválido ou não fornecido"
                        };

                        var response = JsonSerializer.Serialize(new
                        {
                            error = "Unauthorized",
                            message = errorMessage
                        });

                        await context.Response.WriteAsync(response);
                    }
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
using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity;
using SecurityPoliceMG.Domain.Entity.Context;

namespace SecurityPoliceMG.Configuration;

public static class DatabaseConfig
{
    public static IServiceCollection ConfigureDatabase(
        this IServiceCollection services, IConfiguration configuration
    )
    {
        var connectionString = configuration["PostgresSQLConnection:ConnectionString"] ?? "";
        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentException("A string de conexão não está definida!");

        services.AddDbContext<AppDatabaseContext>(options => { options.UseNpgsql(connectionString); });

        return services;
    }
}
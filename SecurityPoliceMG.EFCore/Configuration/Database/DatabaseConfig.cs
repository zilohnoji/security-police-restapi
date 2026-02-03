using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecurityPoliceMG.EFCore.Configuration.Database.Context;

namespace SecurityPoliceMG.EFCore.Configuration.Database;

public static class DatabaseConfig
{
    private static string GetConnectionString(string url, IConfiguration configuration)
    {
        var connectionString = configuration[url] ?? "";
        return !string.IsNullOrEmpty(connectionString)
            ? connectionString
            : throw new ArgumentException("A string de conexão não está definida!");
    }

    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = GetConnectionString("PostgresSQLConnection:Url", configuration);

        services.AddDbContext<AppDbContext>(options => { options.UseNpgsql(connectionString); });

        return services;
    }
}
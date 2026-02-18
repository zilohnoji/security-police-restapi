using SecurityPoliceMG.Configuration.Security;
using SecurityPoliceMG.Configuration.Security.Impl;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Configuration.Database;
using SecurityPoliceMG.EFCore.Repository;
using SecurityPoliceMG.EFCore.Repository.Impl;
using SecurityPoliceMG.Service;
using SecurityPoliceMG.Service.Impl;

namespace SecurityPoliceMG.Configuration;

public static class SetUpInjectableServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddOpenApiServices(configuration)
            .AddRepositoriesServices()
            .AddDatabaseServices(configuration)
            .AddMainServices()
            .AddSecurityServices(configuration);

        return services;
    }

    private static IServiceCollection AddOpenApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureOpenApi();
        services.ConfigureSwagger();
        services.ConfigureCors(configuration);
        return services;
    }

    private static IServiceCollection AddRepositoriesServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

        services.AddScoped<UserRepositoryImpl>();

        services.AddScoped<IRepository<Person>, PersonRepositoryImpl>();
        services.AddScoped<IRepository<User>, UserRepositoryImpl>();

        return services;
    }

    private static IServiceCollection AddMainServices(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IPersonService, PersonServiceImpl>();
        services.AddScoped<IDocumentService, DocumentServiceImpl>();
        services.AddScoped<IUserAuthService, UserServiceImpl>();

        return services;
    }

    private static IServiceCollection AddDatabaseServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.ConfigureDatabase(configuration);
        return services;
    }

    private static IServiceCollection AddSecurityServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.ConfigureSecurity(configuration);
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddScoped<ITokenGenerator, TokenGeneratorConfig>();

        services.AddScoped<IPasswordEncoder, Sha256PasswordEncoder>();

        return services;
    }
}
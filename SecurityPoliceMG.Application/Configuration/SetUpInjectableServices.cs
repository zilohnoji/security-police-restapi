using FluentValidation;
using SecurityPoliceMG.Authentication.Configuration;
using SecurityPoliceMG.Authentication.Configuration.Security.Impl;
using SecurityPoliceMG.Authentication.Service;
using SecurityPoliceMG.Authentication.Service.Impl;
using SecurityPoliceMG.Configuration.Mail;
using SecurityPoliceMG.Configuration.Security;
using SecurityPoliceMG.Configuration.Security.Impl;
using SecurityPoliceMG.EFCore.Configuration.Database;
using SecurityPoliceMG.EFCore.Repository;
using SecurityPoliceMG.EFCore.Repository.Impl;
using SecurityPoliceMG.Service;
using SecurityPoliceMG.Service.Impl.EmailModule;
using SecurityPoliceMG.Service.Impl.PersonModule;
using SecurityPoliceMG.Service.Impl.RequestModule;
using SecurityPoliceMG.Service.Impl.ScaleModule;
using SecurityPoliceMG.Service.Validator.ScaleValidator.AddOnScaleValidation;
using SecurityPoliceMG.Service.Validator.ScaleValidator.AddOnScaleValidation.Validation;

namespace SecurityPoliceMG.Configuration;

public static class SetUpInjectableServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddValidatorsFromAssemblyContaining<Program>()
            .AddValidatorsServices()
            .AddOpenApiServices(configuration)
            .AddRepositoriesServices()
            .AddDatabaseServices(configuration)
            .AddMainServices()
            .AddEmailConfiguration(configuration)
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

    private static IServiceCollection AddValidatorsServices(this IServiceCollection services)
    {
        services.AddScoped<IScaleAddOnScaleValidator, PersonAddOnScaleNotExistsValidation>();
        services.AddScoped<IScaleAddOnScaleValidator, ScaleAddOnScaleConflictValidation>();
        services.AddScoped<IScaleAddOnScaleValidator, ScaleAddOnScaleNotExistsValidation>();

        return services;
    }

    private static IServiceCollection AddRepositoriesServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

        services.AddScoped<UserRepositoryImpl>();
        services.AddScoped<PersonRepositoryImpl>();
        services.AddScoped<ScaleRepositoryImpl>();
        services.AddScoped<RequestRepositoryImpl>();
        services.AddScoped<RequestExchangeScaleRepositoryImpl>();
        services.AddScoped<AddressRepositoryImpl>();

        return services;
    }

    private static IServiceCollection AddMainServices(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IPersonService, PersonServiceImpl>();
        services.AddScoped<IUserAuthService, UserServiceImpl>();
        services.AddScoped<IEmailService, EmailServiceImpl>();
        services.AddScoped<IScaleService, ScaleServiceImpl>();
        services.AddScoped<IRequestService, RequestServiceImpl>();

        services.AddScoped<EmailSender>();

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
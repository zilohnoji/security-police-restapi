namespace SecurityPoliceMG.Configuration.Mail;

public static class MailConfig
{
    public static IServiceCollection AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(GetEmailSettings(configuration));
        return services;
    }

    private static EmailSettings GetEmailSettings(IConfiguration configuration)
    {
        var emailSettings = configuration.GetSection("EmailSettings").Get<EmailSettings>();
        var emailProperties = configuration.Get<EmailSettings.PropertiesSettings>();

        if (emailSettings is null || emailProperties is null)
        {
            throw new ArgumentException("As configurações do Email não foram definidas corretamente!");
        }

        emailSettings.Properties = emailProperties;

        emailSettings.Username = Environment.GetEnvironmentVariable("EMAIL_USERNAME") ?? emailSettings.Username;
        emailSettings.Password = Environment.GetEnvironmentVariable("EMAIL_PASSWORD") ?? emailSettings.Password;

        return emailSettings;
    }
}
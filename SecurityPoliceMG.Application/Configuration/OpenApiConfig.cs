using Microsoft.OpenApi;

namespace SecurityPoliceMG.Configuration;

public static class OpenApiConfig
{
    private const string AppName = "Security Police MG - Rest API";
    private const string AppDescription = "REST API for managing resources on the police platform.";
    private const string AppVersion = "v1";

    private static readonly OpenApiContact AppContact = new OpenApiContact()
    {
        Name = "Pedro Donato",
        Email = "donatopedro.developer@gmail.com",
        Url = new Uri("https://www.linkedin.com/in/joao-pedro-pereira-donato/"),
    };

    private static readonly OpenApiInfo AppInfo = new OpenApiInfo()
    {
        Title = AppName,
        Version = AppVersion,
        Description = AppDescription,
        Contact = AppContact
    };

    public static IServiceCollection ConfigureOpenApi(this IServiceCollection service)
    {
        service.AddSingleton(AppInfo);
        return service;
    }

    public static IServiceCollection ConfigureSwagger(this IServiceCollection service)
    {
        service.AddSwaggerGen(conf => { conf.SwaggerDoc(AppVersion, AppInfo); });
        return service;
    }

    public static IApplicationBuilder UseSwaggerSpecification(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(conf =>
        {
            conf.SwaggerEndpoint("/swagger/v1/swagger.json", AppName);
            conf.RoutePrefix = "swagger-ui";
            conf.DocumentTitle = AppName;
        });

        return app;
    }
}
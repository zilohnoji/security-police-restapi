namespace SecurityPoliceMG.Configuration;

public static class CorsConfig
{
    public static IServiceCollection ConfigureCors(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddCors(options =>
        {
            options.AddPolicy("LocalPolicy", policy =>
                policy
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
        });

        return service;
    }

    public static IApplicationBuilder UseCorsConfig(this IApplicationBuilder app)
    {
        app.UseCors();
        return app;
    }
}
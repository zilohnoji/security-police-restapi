namespace SecurityPoliceMG.Configuration;

public static class CorsConfig
{
    public static IServiceCollection ConfigureCors(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddCors(options =>
        {
            options.AddPolicy("LocalPolicy", policy =>
                policy
                    .WithOrigins("http://localhost:4200", "http://localhost:5000")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        return service;
    }

    public static IApplicationBuilder UseCorsConfig(this IApplicationBuilder app)
    {
        app.UseCors("LocalPolicy");
        return app;
    }
}
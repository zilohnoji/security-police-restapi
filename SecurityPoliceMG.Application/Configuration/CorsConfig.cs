namespace SecurityPoliceMG.Configuration;

public static class CorsConfig
{
    public static void ConfigureCors(this IServiceCollection service, IConfiguration configuration)
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
    }

    public static IApplicationBuilder UseCorsConfig(this IApplicationBuilder app)
    {
        app.UseCors();
        return app;
    }
}
using SecurityPoliceMG.Configuration;
using SecurityPoliceMG.Configuration.Security;
using SecurityPoliceMG.Contract;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Configuration.Database;
using SecurityPoliceMG.EFCore.Repository;
using SecurityPoliceMG.EFCore.Repository.Impl;
using SecurityPoliceMG.Service;
using SecurityPoliceMG.Service.Impl;
using SecurityPoliceMG.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureContentNegotiation();

builder.Services.ConfigureDatabase(builder.Configuration);

builder.Services.ConfigureSecurity(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureOpenApi();

builder.Services.ConfigureSwagger();

builder.Services.ConfigureCors(builder.Configuration);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IPersonService, PersonServiceImpl>();

builder.Services.AddScoped<IDocumentService, DocumentServiceImpl>();

builder.Services.AddScoped<IUserAuthService, UserServiceImpl>();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddScoped<ITokenGenerator, TokenConfig>();

builder.Services.AddScoped<IPasswordEncoder, Sha256PasswordEncoder>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<UserRepositoryImpl>();

builder.Services.AddScoped<IRepository<Person>, PersonRepositoryImpl>();

builder.Services.AddScoped<IRepository<User>, UserRepositoryImpl>();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseCorsConfig();

app.MapControllers();

app.UseSwaggerSpecification();

app.Run();
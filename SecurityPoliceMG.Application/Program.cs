using FluentValidation;
using SecurityPoliceMG.Configuration;
using SecurityPoliceMG.Configuration.Security;
using SecurityPoliceMG.Configuration.Security.Impl;
using SecurityPoliceMG.EFCore.Configuration.Database;
using SecurityPoliceMG.Service;
using SecurityPoliceMG.Service.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureContentNegotiation();

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly, includeInternalTypes: true);

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
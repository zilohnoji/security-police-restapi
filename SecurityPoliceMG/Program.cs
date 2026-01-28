using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity.Context;
using SecurityPoliceMG.Domain.Service;
using SecurityPoliceMG.Repository;
using SecurityPoliceMG.Repository.Impl;
using SecurityPoliceMG.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IPersonService, PersonServiceImpl>();
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImpl>();
builder.Services.AddDbContext<AppDatabaseContext>(options =>
{
    options.UseNpgsql(builder.Configuration["PostgresSQLConnection:ConnectionString"]);
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
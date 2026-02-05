using SecurityPoliceMG.Configuration;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Configuration.Database;
using SecurityPoliceMG.EFCore.Repository;
using SecurityPoliceMG.EFCore.Repository.Impl;
using SecurityPoliceMG.Service;
using SecurityPoliceMG.Service.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureContentNegotiation();
builder.Services.ConfigureDatabase(builder.Configuration);

builder.Services.AddScoped<IPersonService, PersonServiceImpl>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IRepository<Person>, PersonRepositoryImpl>();

// builder.Services.AddScoped<PersonRepositoryImpl>();

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
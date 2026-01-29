using SecurityPoliceMG.Configuration;
using SecurityPoliceMG.Domain.Service;
using SecurityPoliceMG.Repository;
using SecurityPoliceMG.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureContentNegotiation();
builder.Services.ConfigureDatabase(builder.Configuration);


builder.Services.AddScoped<IPersonService, PersonServiceImpl>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


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
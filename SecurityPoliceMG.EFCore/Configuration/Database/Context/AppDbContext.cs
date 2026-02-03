using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.EFCore.Configuration.Database.Context;

public class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public DbSet<Photo> Photos { get; set; }

    public DbSet<City> Cities { get; set; }
    
    public DbSet<Address> Addresses { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
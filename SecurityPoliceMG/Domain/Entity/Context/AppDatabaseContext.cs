using Microsoft.EntityFrameworkCore;

namespace SecurityPoliceMG.Domain.Entity.Context;

public sealed class AppDatabaseContext : DbContext
{
    private AppDatabaseContext()
    {
    }

    public AppDatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
}
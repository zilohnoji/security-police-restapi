using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Configuration.Context;

public sealed class AppDatabaseContext : DbContext
{
    private AppDatabaseContext()
    {
    }

    public AppDatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> Data { get; set; }
}
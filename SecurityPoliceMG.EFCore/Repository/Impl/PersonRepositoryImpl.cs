using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Configuration.Database.Context;

namespace SecurityPoliceMG.EFCore.Repository.Impl;

public class PersonRepositoryImpl(AppDbContext context) : GenericRepository<Person>(context)
{
    public override Person FindById(Guid id)
    {
        return DataSet.Include(p => p.Address.City)
            .Include(p => p.User)
            .Include(p => p.Photo)
            .Include(p => p.PersonScales)
            .ToList()
            .Find(p => p.Id.Equals(id)) ?? throw new ArgumentException($"Person not found by ID {id}");
    }

    public override List<Person> FindAll()
    {
        return DataSet
            .Include(p => p.Address.City)
            .Include(p => p.User)
            .Include(p => p.Photo)
            .Include(p => p.PersonScales)
            .ThenInclude(s => s.Scale)
            .ToList();
    }
}
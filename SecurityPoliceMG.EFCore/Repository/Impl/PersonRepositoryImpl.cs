using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Configuration.Database.Context;
using SecurityPoliceMG.EFCore.Repository.Base;

namespace SecurityPoliceMG.EFCore.Repository.Impl;

public sealed class PersonRepositoryImpl(AppDbContext context) : GenericRepository<Person>(context)
{
    public Person? FindById(Guid id)
    {
        return DataSet.Include(p => p.Address.City)
            .Include(p => p.User)
            .Include(p => p.Photo)
            .Include(p => p.PersonScales)
            .ThenInclude(s => s.Scale)
            .FirstOrDefault(p => p.Id.Equals(id));
    }

    public Page<Person> FindAllInclude(Pageable pageable)
    {
        var query = DataSet
            .Where(p => p.Name.ToLower().Contains(pageable.SearchTerm.ToLower())
                        || p.DaddyName.ToLower().Contains(pageable.SearchTerm.ToLower())
                        || p.MotherName.ToLower().Contains(pageable.SearchTerm.ToLower()))
            .Include(p => p.Address.City)
            .Include(p => p.User)
            .Include(p => p.Photo)
            .Include(p => p.PersonScales)
            .ThenInclude(s => s.Scale);

        return base.FindAll(pageable, query);
    }
}
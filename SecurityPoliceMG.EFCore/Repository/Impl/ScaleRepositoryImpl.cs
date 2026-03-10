using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Configuration.Database.Context;
using SecurityPoliceMG.EFCore.Repository.Base;

namespace SecurityPoliceMG.EFCore.Repository.Impl;

public sealed class ScaleRepositoryImpl(AppDbContext context) : GenericRepository<Scale>(context)
{
    public Scale? FindById(Guid id)
    {
        return DataSet
            .Include(p => p.PersonScales)
            .ThenInclude(p => p.Person)
            .ThenInclude(u => u.User)
            .Include(p => p.PersonScales)
            .ThenInclude(p => p.Person)
            .ThenInclude(a => a.Address)
            .ThenInclude(c => c.City)
            .FirstOrDefault(p => p.Id.Equals(id));
    }

    public Page<Scale> FindAllInclude(Pageable pageable)
    {
        var query = DataSet
            .Where(p => p.Description.ToLower().Contains(pageable.SearchTerm.ToLower())
                        || p.IsCompleted.ToString().ToLower().Contains(pageable.SearchTerm.ToLower()))
            .Include(p => p.PersonScales)
            .ThenInclude(s => s.Person)
            .ThenInclude(s => s.Address);

        return base.FindAll(pageable, query);
    }
}
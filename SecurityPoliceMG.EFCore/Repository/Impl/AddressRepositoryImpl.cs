using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Configuration.Database.Context;
using SecurityPoliceMG.EFCore.Repository.Base;

namespace SecurityPoliceMG.EFCore.Repository.Impl;

public sealed class AddressRepositoryImpl(AppDbContext context) : GenericRepository<Address>(context)
{
    public Address? FindById(Guid id)
    {
        return DataSet.Include(p => p.Persons)
            .ThenInclude(s => s.User)
            .FirstOrDefault(p => p.Id.Equals(id));
    }
}
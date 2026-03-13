using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Configuration.Database.Context;

namespace SecurityPoliceMG.EFCore.Repository.Impl;

public class RequestExchangeScaleRepositoryImpl(AppDbContext context) : GenericRepository<RequestExchangeScale>(context)
{
    public RequestExchangeScale? FindById(Guid id)
    {
        return DataSet.Include(p => p.ReceiverScale)
            .Include(p => p.Request)
            .Include(p => p.RequesterScale)
            .FirstOrDefault(p => p.Id.Equals(id));
    }
}
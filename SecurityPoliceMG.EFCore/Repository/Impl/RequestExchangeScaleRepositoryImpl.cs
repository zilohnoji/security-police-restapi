using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity.Enum;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Configuration.Database.Context;
using SecurityPoliceMG.EFCore.Repository.Base;

namespace SecurityPoliceMG.EFCore.Repository.Impl;

public class RequestExchangeScaleRepositoryImpl(AppDbContext context) : GenericRepository<RequestExchangeScale>(context)
{
    public RequestExchangeScale? FindById(Guid id)
    {
        return DataSet.Include(p => p.ReceiverScale)
            .Include(p => p.Request)
            .Include(p => p.RequesterScale)
            .Include(p => p.RequesterScale.PersonScales)
            .Include(p => p.ReceiverScale.PersonScales)
            .FirstOrDefault(p => p.Id.Equals(id));
    }

    public Page<RequestExchangeScale> GetAllPendingSendRequests(Pageable pageable, Guid loggedUserId)
    {
        var query = DataSet
            .Where(p => p.Request.RequesterId == loggedUserId &&
                        p.Status.ToString().ToLower().Equals(nameof(RequestStatus.Pending).ToLower()))
            .Include(p => p.Request)
            .Include(p => p.ReceiverScale)
            .Include(p => p.RequesterScale);

        return base.FindAll(pageable, query);
    }

    public Page<RequestExchangeScale> GetAllPendingReceivedRequests(Pageable pageable, Guid loggedUserId)
    {
        var query = DataSet
            .Where(p => p.Request.ReceiverId == loggedUserId &&
                        p.Status.ToString().ToLower().Equals(nameof(RequestStatus.Pending).ToLower()))
            .Include(p => p.Request)
            .Include(p => p.ReceiverScale)
            .Include(p => p.RequesterScale);

        return base.FindAll(pageable, query);
    }
}
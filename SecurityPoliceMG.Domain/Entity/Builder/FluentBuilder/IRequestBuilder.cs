using SecurityPoliceMG.Domain.Entity.Enum;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Domain.Entity.Builder.FluentBuilder;

public interface IRequestBuilder : IBuilder<Request>
{
    static abstract IRequestBuilder Builder(Request? entity);

    IRequestBuilder RequesterId(Guid requesterId);

    IRequestBuilder Description(string description);

    IRequestBuilder CreatedAt(DateTime createdAt);

    IRequestBuilder RequestType(RequestType requestType);

    IRequestBuilder ReceiverId(Guid receiverId);

    IRequestBuilder IsCompleted(bool isCompleted);
}
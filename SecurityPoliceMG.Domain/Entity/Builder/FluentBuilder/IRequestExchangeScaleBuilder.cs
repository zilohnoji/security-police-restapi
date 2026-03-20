using SecurityPoliceMG.Domain.Entity.Enum;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Domain.Entity.Builder.FluentBuilder;

public interface IRequestExchangeScaleBuilder : IBuilder<RequestExchangeScale>
{
    static abstract IRequestExchangeScaleBuilder Builder(Request request, RequestExchangeScale? entity);

    IRequestExchangeScaleBuilder Status(RequestStatus status);

    IRequestExchangeScaleBuilder AcceptedAt(DateTime acceptedAt);

    IRequestExchangeScaleBuilder RequesterScaleId(Guid requesterScaleId);

    IRequestExchangeScaleBuilder ReceiverScaleId(Guid? receiverScaleId);
}
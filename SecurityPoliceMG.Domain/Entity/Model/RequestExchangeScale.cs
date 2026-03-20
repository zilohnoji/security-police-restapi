using SecurityPoliceMG.Domain.Entity.Builder.FluentBuilder;
using SecurityPoliceMG.Domain.Entity.Enum;

namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class RequestExchangeScale : BaseEntity
{
    public Guid RequestId { get; private set; }

    public Request Request { get; private set; }

    public RequestStatus Status { get; private set; }

    public DateTime AcceptedAt { get; private set; }

    public Guid RequesterScaleId { get; private set; }

    public Scale RequesterScale { get; private set; }

    public Guid? ReceiverScaleId { get; private set; }

    public Scale ReceiverScale { get; private set; }

    private RequestExchangeScale()
    {
    }

    private RequestExchangeScale(Request requestEntity)
    {
        RequestId = requestEntity.Id;
    }

    public sealed class RequestExchangeScaleBuilder : IRequestExchangeScaleBuilder
    {
        private readonly RequestExchangeScale _entity;

        private RequestExchangeScaleBuilder(Request request, RequestExchangeScale? entity)
        {
            if (entity is not null)
            {
                _entity = entity;
                return;
            }

            _entity = new RequestExchangeScale(request);
        }

        public RequestExchangeScale Build()
        {
            return _entity;
        }

        public static IRequestExchangeScaleBuilder Builder(Request request, RequestExchangeScale? entity = null)
        {
            return new RequestExchangeScaleBuilder(request, entity);
        }

        public IRequestExchangeScaleBuilder Status(RequestStatus status)
        {
            _entity.Status = status;
            return this;
        }

        public IRequestExchangeScaleBuilder AcceptedAt(DateTime acceptedAt)
        {
            _entity.AcceptedAt = acceptedAt;
            return this;
        }

        public IRequestExchangeScaleBuilder RequesterScaleId(Guid requesterScaleId)
        {
            _entity.RequesterScaleId = requesterScaleId;
            return this;
        }

        public IRequestExchangeScaleBuilder ReceiverScaleId(Guid? receiverScaleId)
        {
            _entity.ReceiverScaleId = receiverScaleId;
            return this;
        }
    }
}
using SecurityPoliceMG.Domain.Entity.Builder.FluentBuilder;
using SecurityPoliceMG.Domain.Entity.Enum;

namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class Request : BaseEntity
{
    public Guid RequesterId { get; private set; }

    public Person Requester { get; private set; }

    public string Description { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public RequestType RequestType { get; private set; }

    public Guid ReceiverId { get; private set; }

    public Person Receiver { get; private set; }

    public RequestExchangeScale RequestExchangeScale { get; private set; }

    public bool IsCompleted { get; private set; }

    private Request()
    {
    }

    public sealed class RequestBuilder : IRequestBuilder
    {
        private readonly Request _entity;

        private RequestBuilder(Request? entity)
        {
            if (entity is not null)
            {
                _entity = entity;
                return;
            }

            _entity = new Request();
        }

        public Request Build()
        {
            return _entity;
        }

        public static IRequestBuilder Builder(Request? entity = null)
        {
            return new RequestBuilder(entity);
        }

        public IRequestBuilder RequesterId(Guid requesterId)
        {
            _entity.RequesterId = requesterId;
            return this;
        }

        public IRequestBuilder Description(string description)
        {
            _entity.Description = description;
            return this;
        }

        public IRequestBuilder CreatedAt(DateTime createdAt)
        {
            _entity.CreatedAt = createdAt;
            return this;
        }

        public IRequestBuilder RequestType(RequestType requestType)
        {
            _entity.RequestType = requestType;
            return this;
        }

        public IRequestBuilder ReceiverId(Guid receiverId)
        {
            _entity.ReceiverId = receiverId;
            return this;
        }

        public IRequestBuilder IsCompleted(bool isCompleted)
        {
            _entity.IsCompleted = isCompleted;
            return this;
        }
    }
}
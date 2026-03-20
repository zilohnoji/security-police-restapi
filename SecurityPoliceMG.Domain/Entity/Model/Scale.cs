using SecurityPoliceMG.Domain.Entity.Builder.FluentBuilder;
using SecurityPoliceMG.Domain.Entity.Enum;

namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class Scale : BaseEntity
{
    public bool IsCompleted { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime StartsAt { get; private set; }

    public DateTime FinishedAt { get; private set; }

    public string Description { get; private set; }

    public ScaleStatus Status { get; private set; }

    public ICollection<PersonScale> PersonScales { get; private set; } = [];

    public ICollection<RequestExchangeScale> RequestExchangeScales { get; private set; } = [];

    public ICollection<RequestExchangeScale> ReceiverExchangeScales { get; private set; } = [];

    private Scale()
    {
    }

    public sealed class ScaleBuilder : IScaleBuilder
    {
        private readonly Scale _entity;

        private ScaleBuilder(Scale? entity)
        {
            if (entity is not null)
            {
                _entity = entity;
                return;
            }

            _entity = new Scale();
        }

        public Scale Build()
        {
            return _entity;
        }

        public static IScaleBuilder Builder(Scale? entity = null)
        {
            return new ScaleBuilder(entity);
        }

        public IScaleBuilder IsCompleted(bool isCompleted)
        {
            _entity.IsCompleted = isCompleted;
            return this;
        }

        public IScaleBuilder CreatedAt(DateTime createdAt)
        {
            _entity.CreatedAt = createdAt;
            return this;
        }

        public IScaleBuilder StartsAt(DateTime startsAt)
        {
            _entity.StartsAt = startsAt;
            return this;
        }

        public IScaleBuilder FinishedAt(DateTime finishedAt)
        {
            _entity.FinishedAt = finishedAt;
            return this;
        }

        public IScaleBuilder Description(string description)
        {
            _entity.Description = description;
            return this;
        }

        public IScaleBuilder Status(ScaleStatus status)
        {
            _entity.Status = status;
            return this;
        }
    }
}
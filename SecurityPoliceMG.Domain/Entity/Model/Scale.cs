using SecurityPoliceMG.Domain.Entity.Builder.FluentBuilder;

namespace SecurityPoliceMG.Domain.Entity.Model;

public class Scale : BaseEntity
{
    public bool IsCompleted { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime StartsAt { get; private set; }

    public DateTime FinishedAt { get; private set; }

    public string Description { get; private set; } = string.Empty;

    public ICollection<PersonScale> PersonScales { get; private set; } = new List<PersonScale>();

    public static readonly Scale Empty = new Scale();
    
    private Scale()
    {
    }

    public sealed class ScaleBuilder : IScaleBuilder
    {
        private readonly Scale _entity;

        private ScaleBuilder()
        {
            _entity = new Scale();
        }

        public Scale Build()
        {
            return _entity;
        }

        public static IScaleBuilder Builder()
        {
            return new ScaleBuilder();
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
    }
}
namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class Photo : BaseEntity
{
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public string Bucket { get; private set; } = string.Empty;

    public string Hash { get; private set; } = string.Empty;

    public Guid PersonId { get; private set; } = Guid.Empty;

    public Person Person { get; private set; } = Person.Empty;

    public static readonly Photo Empty = new Photo();

    private Photo()
    {
    }

    private Photo(string bucket, string hash)
    {
        Bucket = bucket;
        Hash = hash;
    }

    public static Photo Of(string bucket, string hash)
    {
        return new Photo(bucket, hash);
    }
}
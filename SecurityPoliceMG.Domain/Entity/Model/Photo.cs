namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class Photo : BaseEntity
{
    public DateTime CreatedAt { get; private set; }

    public string Bucket { get; private set; }

    public string Hash { get; private set; }

    public Guid PersonId { get; private set; }

    public Person? Person { get; private set; }

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
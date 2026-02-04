using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityPoliceMG.Domain.Entity.Model;

[Table("tb_photo")]
public sealed class Photo : BaseEntity
{
    [Column("created_at")] public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    [Required]
    [MaxLength(50)]
    [Column("bucket")]
    public string Bucket { get; private set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    [Column("hash")]
    public string Hash { get; private set; } = string.Empty;

    [Required] [Column("person_id")] public Guid PersonId { get; private set; } = Guid.Empty;

    [Required] public Person Person { get; private set; } = Person.Empty;

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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityPoliceMG.Domain.Entity.Model;

[Table("photo")]
public sealed class Photo : BaseEntity
{
    [Required]
    [Column("created_at", TypeName = "date")]
    public DateTime CreatedAt { get; private set; }

    [Required]
    [MaxLength(50)]
    [Column("bucket", TypeName = "varchar(50)")]
    public string Bucket { get; private set; }

    [Required]
    [MaxLength(50)]
    [Column("hash", TypeName = "varchar(50)")]
    public string Hash { get; private set; }

    [Required]
    [Column("person_id", TypeName = "uuid")]
    public Guid PersonId { get; private set; }

    public Person Person { get; private set; }

    public static readonly Photo Empty = new Photo();

    private Photo()
    {
        CreatedAt = DateTime.Now;
        Bucket = string.Empty;
        Hash = string.Empty;
        Person = Person.Empty;
    }
}
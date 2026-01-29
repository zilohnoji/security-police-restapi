using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityPoliceMG.Domain.Entity.Model;

[Table("photo")]
public class Photo : BaseEntity
{
    [Required]
    [Column("person_id", TypeName = "uuid")]
    public Guid PersonId { get; private set; }

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

    private Photo()
    {
        PersonId = Guid.Empty;
        CreatedAt = DateTime.Now;
        Bucket = string.Empty;
        Hash = string.Empty;
    }
}
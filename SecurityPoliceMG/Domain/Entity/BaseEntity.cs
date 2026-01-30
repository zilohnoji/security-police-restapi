using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityPoliceMG.Domain.Entity;

public abstract class BaseEntity
{
    [Key]
    [Column("id", TypeName = "uuid")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual Guid Id { get; protected set; }

    protected BaseEntity()
    {
    }
}
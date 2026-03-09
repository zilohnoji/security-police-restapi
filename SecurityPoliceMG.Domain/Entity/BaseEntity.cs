using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityPoliceMG.Domain.Entity;

public abstract class BaseEntity
{
    [Column("id", TypeName = "uuid")] public Guid Id { get; protected set; }

    protected BaseEntity()
    {
    }
}
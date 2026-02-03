using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityPoliceMG.Domain.Entity;

public abstract class BaseEntity
{
    [Column("id", TypeName = "uuid")]
    public virtual Guid Id { get; protected set; }
    
    protected BaseEntity(){}
    
}
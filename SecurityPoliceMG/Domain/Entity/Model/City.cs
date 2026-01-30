using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityPoliceMG.Domain.Entity.Model;

[Table("city")]
public sealed class City : BaseEntity
{
    [Required]
    [Column("name", TypeName = "varchar(200)")]
    public string Name { get; private set; }

    [Required]
    [Column("uf", TypeName = "varchar(2)")]
    public string Uf { get; private set; }

    public static readonly City Empty = new City();

    private City()
    {
        Name = string.Empty;
        Uf = string.Empty;
    }
}
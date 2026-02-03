using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityPoliceMG.Domain.Entity.Model;

[Table("tb_city")]
public sealed class City : BaseEntity
{
    [Required]
    [MaxLength(200)]
    [Column("name")]
    public string Name { get; private set; } = string.Empty;

    [Required]
    [MaxLength(2)]
    [Column("uf")]
    public string Uf { get; private set; } = string.Empty;

    public static readonly City Empty = new City();

    private City()
    {
    }

    private City(string name, string uf)
    {
        Name = name;
        Uf = uf;
    }

    public static City Of(string name, string uf)
    {
        return new City(name, uf);
    }
}
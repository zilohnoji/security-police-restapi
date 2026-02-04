using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityPoliceMG.Domain.Entity.Model;

[Table("tb_user")]
public sealed class User : BaseEntity
{
    [Required]
    [Column("email", TypeName = "varchar(100)")]
    public string Email { get; private set; } = string.Empty;

    [Required]
    [Column("password", TypeName = "varchar(200)")]
    public string Password { get; private set; } = string.Empty;

    public Person Person { get; private set; } = Person.Empty;

    public static readonly User Empty = new User();

    private User()
    {
    }

    private User(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public static User Of(string email, string password)
    {
        return new User(email, password);
    }
}
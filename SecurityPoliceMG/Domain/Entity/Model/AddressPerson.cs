using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityPoliceMG.Domain.Entity.Model;

[Table("address_person")]
public sealed class AddressPerson : BaseEntity
{
    [Required]
    [Column("person_id", TypeName = "uuid")]
    public Guid PersonId { get; private set; }

    [Required]
    [ForeignKey(nameof(PersonId))]
    public Person Person { get; private set; }

    [Required]
    [Column("address_id", TypeName = "uuid")]
    public Guid AddressId { get; private set; }

    [Required]
    [ForeignKey(nameof(AddressId))]
    public Address Address { get; private set; }
    
    private AddressPerson()
    {
        PersonId = Guid.Empty;
        AddressId = Guid.Empty;
        Address = Address.Empty;
        Person = Person.Empty;
    }
}
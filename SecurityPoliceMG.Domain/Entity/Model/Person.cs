using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SecurityPoliceMG.Domain.Entity.Builder.FluentBuilder;

namespace SecurityPoliceMG.Domain.Entity.Model;

[Table("tb_person")]
public sealed class Person : BaseEntity
{
    [Required]
    [MaxLength(200)]
    [Column("name")]
    public string Name { get; private set; } = string.Empty;

    [Required] [Column("birth_date")] public DateTime BirthDate { get; private set; } = DateTime.Now;

    [Required]
    [MaxLength(9)]
    [Column("gender")]
    public string Gender { get; private set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    [Column("mother_name")]
    public string MotherName { get; private set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    [Column("daddy_name")]
    public string DaddyName { get; private set; } = string.Empty;

    [Required] [Column("address_id")] public Guid AddressId { get; private set; } = Guid.Empty;

    [Required] public Address Address { get; private set; } = Address.Empty;

    public static readonly Person Empty = new Person();

    public sealed class PersonBuilder : IPersonBuilder
    {
        private readonly Person _entity;

        private PersonBuilder()
        {
            _entity = new Person();
        }

        public Person Build()
        {
            return _entity;
        }

        public static IPersonBuilder Builder()
        {
            return new PersonBuilder();
        }

        public IPersonBuilder Name(string name)
        {
            _entity.Name = name;
            return this;
        }

        public IPersonBuilder BirthDate(DateTime birthDate)
        {
            _entity.BirthDate = DateTime.SpecifyKind(birthDate, DateTimeKind.Utc);
            return this;
        }

        public IPersonBuilder Gender(string gender)
        {
            _entity.Gender = gender;
            return this;
        }

        public IPersonBuilder MotherName(string motherName)
        {
            _entity.MotherName = motherName;
            return this;
        }

        public IPersonBuilder DaddyName(string daddyName)
        {
            _entity.DaddyName = daddyName;
            return this;
        }

        public IPersonBuilder Address(Address address)
        {
            _entity.AddressId = address.Id;
            _entity.Address = address;
            return this;
        }
    }
}
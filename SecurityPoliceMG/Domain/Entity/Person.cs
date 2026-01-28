using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SecurityPoliceMG.Application.Builder.Entity;

namespace SecurityPoliceMG.Domain.Entity;

[Table("person")]
public sealed class Person : BaseEntity
{
    [Required]
    [MaxLength(200)]
    [Column("name", TypeName = "varchar(200)")]
    public string Name { get; private set; }

    [Required]
    [Column("birth_date", TypeName = "date")]
    public DateTime BirthDate { get; private set; }

    [Required]
    [MaxLength(9)]
    [Column("gender", TypeName = "varchar(9)")]
    public string Gender { get; private set; }

    [Required]
    [MaxLength(200)]
    [Column("mother_name", TypeName = "varchar(200)")]
    public string MotherName { get; private set; }

    [Required]
    [MaxLength(200)]
    [Column("daddy_name", TypeName = "varchar(200)")]
    public string DaddyName { get; private set; }

    private Person()
    {
        Name = string.Empty;
        BirthDate = DateTime.Now;
        Gender = string.Empty;
        MotherName = string.Empty;
        DaddyName = string.Empty;
    }

    public sealed class PersonBuilder : IPersonFluentBuilder
    {
        private readonly Person _entity;

        private PersonBuilder()
        {
            this._entity = new Person();
        }

        public static PersonBuilder Builder()
        {
            return new PersonBuilder();
        }

        public Person Build()
        {
            return _entity;
        }

        public IPersonFluentBuilder Name(string name)
        {
            _entity.Name = name;
            return this;
        }

        public IPersonFluentBuilder BirthDate(DateTime birthDate)
        {
            _entity.BirthDate = birthDate;
            return this;
        }

        public IPersonFluentBuilder Gender(string gender)
        {
            _entity.Gender = gender;
            return this;
        }

        public IPersonFluentBuilder MotherName(string motherName)
        {
            _entity.MotherName = motherName;
            return this;
        }

        public IPersonFluentBuilder DaddyName(string daddyName)
        {
            _entity.DaddyName = daddyName;
            return this;
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SecurityPoliceMG.Domain.Entity.Builder.FluentBuilder;

namespace SecurityPoliceMG.Domain.Entity.Model;

[Table("tb_address")]
public sealed class Address : BaseEntity
{
    [Required]
    [MaxLength(50)]
    [Column("patio_type")]
    public string PatioType { get; private set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    [Column("street")]
    public string Street { get; private set; } = string.Empty;

    [Required] [Column("number")] public int Number { get; private set; }

    [Required]
    [MaxLength(100)]
    [Column("neighborhood")]
    public string Neighborhood { get; private set; } = string.Empty;

    [Required] [Column("city_id")] public Guid CityId { get; private set; } = Guid.Empty;

    [Required] public City City { get; private set; } = City.Empty;

    public List<Person> Persons { get; private set; } = [];

    public static readonly Address Empty = new Address();

    public sealed class AddressBuilder : IAddressBuilder
    {
        private readonly Address _entity;

        private AddressBuilder()
        {
            _entity = new Address();
        }

        public Address Build()
        {
            return _entity;
        }

        public static IAddressBuilder Builder()
        {
            return new AddressBuilder();
        }

        public IAddressBuilder PatioType(string patioType)
        {
            _entity.PatioType = patioType;
            return this;
        }

        public IAddressBuilder Street(string street)
        {
            _entity.Street = street;
            return this;
        }

        public IAddressBuilder Number(int number)
        {
            _entity.Number = number;
            return this;
        }

        public IAddressBuilder Neighborhood(string neighborhood)
        {
            _entity.Neighborhood = neighborhood;
            return this;
        }

        public IAddressBuilder City(City city)
        {
            _entity.CityId = city.Id;
            _entity.City = city;
            return this;
        }
    }

    public void DefineCity(City city)
    {
        City = city;
        CityId = city.Id;
    }

}
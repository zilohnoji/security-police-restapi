using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityPoliceMG.Domain.Entity.Model;

[Table("address")]
public sealed class Address : BaseEntity
{
    public string PatioType { get; private set; }
    
    public string Street { get; private set; }
    
    public int Number { get; private set; }
    
    public string Neighborhood { get; private set; }
    
    public Guid CityId { get; private set; }
    
    public City City { get; private set; }

    public static readonly Address Empty = new Address();
    
    private Address()
    {
        PatioType = string.Empty;
        Street = string.Empty;
        Neighborhood = string.Empty;
        City = City.Empty;
    }
}
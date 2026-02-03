using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Domain.Entity.Builder.FluentBuilder;

public interface IAddressBuilder : IBuilder<Address>
{
    static abstract IAddressBuilder Builder();

    IAddressBuilder PatioType(string patioType);

    IAddressBuilder Street(string street);

    IAddressBuilder Number(int number);

    IAddressBuilder Neighborhood(string neighborhood);
    
    IAddressBuilder City(City city);
}
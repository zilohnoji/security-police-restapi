using SecurityPoliceMG.Api.Dto.Person.Response;

namespace SecurityPoliceMG.Application.Builder.Dto.Response;

public interface IAddressDetailsResponseDtoFluentBuilder : IBuilder<AddressDetailsResponseDto>
{
    static abstract IAddressDetailsResponseDtoFluentBuilder Builder();
    
    IAddressDetailsResponseDtoFluentBuilder PatioType(string patioType);

    IAddressDetailsResponseDtoFluentBuilder Street(string street);

    IAddressDetailsResponseDtoFluentBuilder Number(int number);

    IAddressDetailsResponseDtoFluentBuilder Neighborhood(string neighborhood);

    IAddressDetailsResponseDtoFluentBuilder City(CityDetailsResponseDto city);
}
using SecurityPoliceMG.Api.Dto.Address.Response;
using SecurityPoliceMG.Api.Dto.City.Response;

namespace SecurityPoliceMG.Api.Dto.Builder.FluentBuilder.Response;

public interface IAddressDetailsResponseDtoBuilder : IBuilder<AddressDetailsResponseDto>
{
    static abstract IAddressDetailsResponseDtoBuilder Builder();
    
    IAddressDetailsResponseDtoBuilder PatioType(string patioType);

    IAddressDetailsResponseDtoBuilder Street(string street);

    IAddressDetailsResponseDtoBuilder Number(int number);

    IAddressDetailsResponseDtoBuilder Neighborhood(string neighborhood);

    IAddressDetailsResponseDtoBuilder City(CityDetailsResponseDto city);
}
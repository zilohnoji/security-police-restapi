using SecurityPoliceMG.Api.Dto.Builder.FluentBuilder.Response;
using SecurityPoliceMG.Api.Dto.City.Response;

namespace SecurityPoliceMG.Api.Dto.Address.Response;

public sealed class AddressDetailsResponseDto
{
    public string PatioType { get; set; }

    public string Street { get; set; }

    public int Number { get; set; }

    public string Neighborhood { get; set; }

    public CityDetailsResponseDto City { get; set; }

    private AddressDetailsResponseDto()
    {
    }

    public sealed class AddressDetailsBuilder : IAddressDetailsResponseDtoBuilder
    {
        private readonly AddressDetailsResponseDto _dto;

        private AddressDetailsBuilder()
        {
            _dto = new AddressDetailsResponseDto();
        }

        public AddressDetailsResponseDto Build()
        {
            return _dto;
        }

        public static IAddressDetailsResponseDtoBuilder Builder()
        {
            return new AddressDetailsBuilder();
        }

        public IAddressDetailsResponseDtoBuilder PatioType(string patioType)
        {
            _dto.PatioType = patioType;
            return this;
        }

        public IAddressDetailsResponseDtoBuilder Street(string street)
        {
            _dto.Street = street;
            return this;
        }

        public IAddressDetailsResponseDtoBuilder Number(int number)
        {
            _dto.Number = number;
            return this;
        }

        public IAddressDetailsResponseDtoBuilder Neighborhood(string neighborhood)
        {
            _dto.Neighborhood = neighborhood;
            return this;
        }

        public IAddressDetailsResponseDtoBuilder City(CityDetailsResponseDto city)
        {
            _dto.City = city;
            return this;
        }
    }
}
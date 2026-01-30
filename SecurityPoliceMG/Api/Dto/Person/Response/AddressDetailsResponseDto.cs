using System.Text.Json.Serialization;
using SecurityPoliceMG.Application.Builder.Dto.Response;

namespace SecurityPoliceMG.Api.Dto.Person.Response;

public sealed class AddressDetailsResponseDto
{
    [JsonPropertyName("patio_type")] public string PatioType { get; private set; }

    public string Street { get; private set; }

    public int Number { get; private set; }

    public string Neighborhood { get; private set; }

    public CityDetailsResponseDto City { get; private set; }

    public static readonly AddressDetailsResponseDto Empty = new AddressDetailsResponseDto();

    private AddressDetailsResponseDto()
    {
        PatioType = string.Empty;
        Street = string.Empty;
        Neighborhood = string.Empty;
        City = CityDetailsResponseDto.Empty;
    }

    public sealed class AddressDetailsBuilder : IAddressDetailsResponseDtoFluentBuilder
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

        public static IAddressDetailsResponseDtoFluentBuilder Builder()
        {
            return new AddressDetailsBuilder();
        }

        public IAddressDetailsResponseDtoFluentBuilder PatioType(string patioType)
        {
            _dto.PatioType = patioType;
            return this;
        }

        public IAddressDetailsResponseDtoFluentBuilder Street(string street)
        {
            _dto.Street = street;
            return this;
        }

        public IAddressDetailsResponseDtoFluentBuilder Number(int number)
        {
            _dto.Number = number;
            return this;
        }

        public IAddressDetailsResponseDtoFluentBuilder Neighborhood(string neighborhood)
        {
            _dto.Neighborhood = neighborhood;
            return this;
        }

        public IAddressDetailsResponseDtoFluentBuilder City(CityDetailsResponseDto city)
        {
            _dto.City = city;
            return this;
        }
    }
}
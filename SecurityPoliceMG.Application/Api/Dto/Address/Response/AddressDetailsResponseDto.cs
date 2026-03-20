using SecurityPoliceMG.Api.Dto.City.Response;

namespace SecurityPoliceMG.Api.Dto.Address.Response;

public sealed class AddressDetailsResponseDto
{
    public string PatioType { get; set; }

    public string Street { get; set; }

    public int Number { get; set; }

    public string Neighborhood { get; set; }

    public CityDetailsResponseDto City { get; set; }
}
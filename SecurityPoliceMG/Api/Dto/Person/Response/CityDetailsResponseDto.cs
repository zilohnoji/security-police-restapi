namespace SecurityPoliceMG.Api.Dto.Person.Response;

public sealed class CityDetailsResponseDto
{
    public string Name { get; private set; }

    public string Uf { get; private set; }

    public static readonly CityDetailsResponseDto Empty = new CityDetailsResponseDto();

    private CityDetailsResponseDto()
    {
        Name = string.Empty;
        Uf = string.Empty;
    }

    public CityDetailsResponseDto(string name, string uf)
    {
        Name = name;
        Uf = uf;
    }
}
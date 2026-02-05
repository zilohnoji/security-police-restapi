namespace SecurityPoliceMG.Api.Dto.Person.Response;

public sealed class CityDetailsResponseDto
{
    public string Name { get; set; }

    public string Uf { get; set; }

    public static readonly CityDetailsResponseDto Empty = new CityDetailsResponseDto();

    public CityDetailsResponseDto()
    {
        Name = string.Empty;
        Uf = string.Empty;
    }

    private CityDetailsResponseDto(string name, string uf)
    {
        Name = name;
        Uf = uf;
    }

    public static CityDetailsResponseDto Of(string name, string uf)
    {
        return new CityDetailsResponseDto(name, uf);
    }
}
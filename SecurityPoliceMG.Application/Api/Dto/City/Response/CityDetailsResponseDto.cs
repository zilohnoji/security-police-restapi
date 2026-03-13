namespace SecurityPoliceMG.Api.Dto.City.Response;

public sealed class CityDetailsResponseDto
{
    public string Name { get; set; }

    public string Uf { get; set; }

    private CityDetailsResponseDto()
    {
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
using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.Person.Response;

public sealed class CityDetailsResponseDto
{
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("uf")] public string Uf { get; set; }

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
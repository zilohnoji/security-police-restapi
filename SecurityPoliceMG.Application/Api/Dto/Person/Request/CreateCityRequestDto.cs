using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.Person.Request;

public sealed class CreateCityRequestDto
{
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("uf")] public string Uf { get; set; }

    public static readonly CreateCityRequestDto Empty = new CreateCityRequestDto();

    public CreateCityRequestDto()
    {
        Name = string.Empty;
        Uf = string.Empty;
    }

    private CreateCityRequestDto(string name, string uf)
    {
        Name = name;
        Uf = uf;
    }

    public static CreateCityRequestDto Of(string name, string uf)
    {
        return new CreateCityRequestDto(name, uf);
    }
}
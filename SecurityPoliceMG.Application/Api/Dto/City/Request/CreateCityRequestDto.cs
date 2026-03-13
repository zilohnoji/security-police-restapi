using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.City.Request;

public record CreateCityRequestDto
{
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("uf")] public string Uf { get; set; }
}
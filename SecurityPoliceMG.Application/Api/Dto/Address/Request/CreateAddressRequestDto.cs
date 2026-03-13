using System.Text.Json.Serialization;
using SecurityPoliceMG.Api.Dto.City.Request;

namespace SecurityPoliceMG.Api.Dto.Address.Request;

public record CreateAddressRequestDto
{
    [JsonPropertyName("street_type")] public string PatioType { get; set; }

    [JsonPropertyName("street")] public string Street { get; set; }

    [JsonPropertyName("number")] public int Number { get; set; }

    [JsonPropertyName("neighborhood")] public string Neighborhood { get; set; }

    [JsonPropertyName("city")] public CreateCityRequestDto City { get; set; }
};
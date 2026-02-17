using System.Text.Json.Serialization;
using SecurityPoliceMG.Api.Dto.City.Request;

namespace SecurityPoliceMG.Api.Dto.Address.Request;

public sealed class CreateAddressRequestDto
{
    [JsonPropertyName("street_type")] public string PatioType { get; set; } = string.Empty;

    [JsonPropertyName("street")] public string Street { get; set; } = string.Empty;

    [JsonPropertyName("number")] public int Number { get; set; }

    [JsonPropertyName("neighborhood")] public string Neighborhood { get; set; } = string.Empty;

    [JsonPropertyName("city")] public CreateCityRequestDto City { get; set; } = new CreateCityRequestDto();
};
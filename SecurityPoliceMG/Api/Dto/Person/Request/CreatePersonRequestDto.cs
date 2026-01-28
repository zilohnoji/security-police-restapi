using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.Person.Request;

public record CreatePersonRequestDto
{
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("birth_date")] public string BirthDate { get; set; } = string.Empty;
    [JsonPropertyName("gender")] public string Gender { get; private set; } = string.Empty;
    [JsonPropertyName("mother_name")] public string MotherName { get; set; } = string.Empty;
    [JsonPropertyName("daddy_name")] public string DaddyName { get; set; } = string.Empty;
};
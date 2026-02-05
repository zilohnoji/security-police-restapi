using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.Scale.Request;

public record CreateScaleRequestDto
{
    [JsonPropertyName("person_id")] public string PersonId { get; set; } = string.Empty;

    [JsonPropertyName("description")] public string Description { get; set; } = string.Empty;

    [JsonPropertyName("starts_at")] public string StartsAt { get; set; } = string.Empty;

    [JsonPropertyName("finished_at")] public string FinishedAt { get; set; } = string.Empty;
};
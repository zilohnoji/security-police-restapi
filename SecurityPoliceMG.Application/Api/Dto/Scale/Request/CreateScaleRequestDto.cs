using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.Scale.Request;

public record CreateScaleRequestDto
{
    [JsonPropertyName("description")] public string Description { get; set; }

    [JsonPropertyName("starts_at")] public string StartsAt { get; set; }

    [JsonPropertyName("finished_at")] public string FinishedAt { get; set; }
};
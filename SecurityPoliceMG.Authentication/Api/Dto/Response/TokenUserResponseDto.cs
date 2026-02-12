using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.Response;

public record TokenUserResponseDto
{
    [JsonPropertyName("access_token")] public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("refresh_token")] public string RefreshToken { get; set; } = string.Empty;
}
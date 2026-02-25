using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.User.Request;

public record RefreshTokenRequestDto
{
    [JsonPropertyName("refresh_token")] public string RefreshToken { get; set; } = string.Empty;

    [JsonPropertyName("expired_access_token")]
    public string ExpiredAccessToken { get; set; } = string.Empty;
}
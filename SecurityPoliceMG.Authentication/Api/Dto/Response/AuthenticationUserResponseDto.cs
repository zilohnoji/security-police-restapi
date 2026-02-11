using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.User.Response;

public record AuthenticationUserResponseDto
{
    [JsonPropertyName("email")] public string Email { get; set; } = string.Empty;

    [JsonPropertyName("authenticated")] public bool Authenticated { get; set; }

    [JsonPropertyName("access_token")] public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("refresh_token")] public string RefreshToken { get; set; } = string.Empty;
}
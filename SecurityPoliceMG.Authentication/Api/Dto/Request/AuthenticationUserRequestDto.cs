using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.User.Request;

public record AuthenticationUserRequestDto
{
    [JsonPropertyName("email")] public string Email { get; set; } = string.Empty;

    [JsonPropertyName("password")] public string Password { get; set; } = string.Empty;
}
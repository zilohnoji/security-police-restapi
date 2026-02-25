using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.User.Response;

public class TokenUserResponseDto
{
    [JsonPropertyName("access_token")] public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("refresh_token")] public string RefreshToken { get; set; } = string.Empty;

    private TokenUserResponseDto()
    {
    }

    private TokenUserResponseDto(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public static TokenUserResponseDto Of(string accessToken, string refreshToken)
    {
        return new TokenUserResponseDto(accessToken, refreshToken);
    }
}
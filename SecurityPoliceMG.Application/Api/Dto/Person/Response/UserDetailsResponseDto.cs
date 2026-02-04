using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.Person.Response;

public record UserDetailsResponseDto
{
    [JsonPropertyName("email")] public string Email { get; set; } = string.Empty;

    [JsonPropertyName("password")] public string Password { get; set; } = string.Empty;

    public static readonly UserDetailsResponseDto Empty = new UserDetailsResponseDto();
    
    private UserDetailsResponseDto()
    {
    }

    public UserDetailsResponseDto(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
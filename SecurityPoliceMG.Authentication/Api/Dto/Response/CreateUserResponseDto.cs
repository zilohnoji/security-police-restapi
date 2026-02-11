using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.User.Response;

public class CreateUserResponseDto
{
    [JsonPropertyName("id")] public string Id { get; private set; } = string.Empty;
    [JsonPropertyName("email")] public string Email { get; private set; } = string.Empty;

    private CreateUserResponseDto()
    {
    }

    private CreateUserResponseDto(string id, string email)
    {
        Id = id;
        Email = email;
    }

    public static CreateUserResponseDto Of(string id, string email)
    {
        return new CreateUserResponseDto(id, email);
    }
}
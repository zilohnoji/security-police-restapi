namespace SecurityPoliceMG.Api.Dto.Person.Response;

public record UserDetailsResponseDto
{
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public static readonly UserDetailsResponseDto Empty = new UserDetailsResponseDto();

    private UserDetailsResponseDto()
    {
    }

    private UserDetailsResponseDto(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public static UserDetailsResponseDto Of(string email, string password)
    {
        return new UserDetailsResponseDto(email, password);
    }
}
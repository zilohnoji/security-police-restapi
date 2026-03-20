using SecurityPoliceMG.Api.Dto.Address.Response;
using SecurityPoliceMG.Api.Dto.Scale.Response;

namespace SecurityPoliceMG.Api.Dto.Person.Response;

public sealed class PersonDetailsResponseDto
{
    public Guid Id { get; set; }

    public ProfileResponse Profile { get; set; }

    public AddressDetailsResponseDto Address { get; set; }

    public ICollection<ScaleDetailsResponseDto> Scales { get; set; } = new List<ScaleDetailsResponseDto>();
}

public sealed class ProfileResponse
{
    public string Name { get; set; }

    public DateOnly BirthDate { get; set; }

    public string Gender { get; set; }

    public string MotherName { get; set; }

    public string DaddyName { get; set; }
}
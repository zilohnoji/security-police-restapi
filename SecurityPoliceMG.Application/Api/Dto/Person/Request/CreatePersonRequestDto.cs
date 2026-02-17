using System.Text.Json.Serialization;
using SecurityPoliceMG.Api.Dto.Address.Request;
using SecurityPoliceMG.Api.Dto.Photo.Request;

namespace SecurityPoliceMG.Api.Dto.Person.Request;

public record CreatePersonRequestDto
{
    [JsonPropertyName("profile")] public ProfileRequest Profile { get; set; } = new ProfileRequest();

    [JsonPropertyName("address")] public CreateAddressRequestDto Address { get; set; } = new CreateAddressRequestDto();
};

public sealed class ProfileRequest
{
    [JsonPropertyName("full_name")] public string Name { get; set; } = string.Empty;

    [JsonPropertyName("birth_date")] public string BirthDate { get; set; } = string.Empty;

    [JsonPropertyName("gender")] public string Gender { get; set; } = string.Empty;

    [JsonPropertyName("mother_name")] public string MotherName { get; set; } = string.Empty;

    [JsonPropertyName("father_name")] public string DaddyName { get; set; } = string.Empty;

    [JsonPropertyName("photo")] public CreatePhotoRequestDto Photo { get; set; } = new CreatePhotoRequestDto();
};


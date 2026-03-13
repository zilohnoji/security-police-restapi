using System.Text.Json.Serialization;
using SecurityPoliceMG.Api.Dto.Address.Request;
using SecurityPoliceMG.Api.Dto.Photo.Request;

namespace SecurityPoliceMG.Api.Dto.Person.Request;

public record CreatePersonRequestDto
{
    [JsonPropertyName("profile")] public ProfileRequest Profile { get; set; }

    [JsonPropertyName("address")] public CreateAddressRequestDto Address { get; set; }
};

public sealed class ProfileRequest
{
    [JsonPropertyName("full_name")] public string Name { get; set; }

    [JsonPropertyName("birth_date")] public string BirthDate { get; set; }

    [JsonPropertyName("gender")] public string Gender { get; set; }

    [JsonPropertyName("mother_name")] public string MotherName { get; set; }

    [JsonPropertyName("father_name")] public string DaddyName { get; set; }

    [JsonPropertyName("photo")] public CreatePhotoRequestDto Photo { get; set; }
};
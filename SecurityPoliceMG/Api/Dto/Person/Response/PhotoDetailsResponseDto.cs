using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.Person.Response;

public sealed class PhotoDetailsResponseDto
{
    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; private set; }

    public string Bucket { get; private set; }

    public string Hash { get; private set; }

    public static readonly PhotoDetailsResponseDto Empty = new PhotoDetailsResponseDto();

    private PhotoDetailsResponseDto()
    {
        CreatedAt = DateTime.Now;
        Bucket = string.Empty;
        Hash = string.Empty;
    }

    public PhotoDetailsResponseDto(string bucket, string hash)
    {
        Bucket = bucket;
        Hash = hash;
        CreatedAt = DateTime.Now;
    }
}
using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.Photo.Request;

public record CreatePhotoRequestDto
{
    [JsonPropertyName("bucket")] public string Bucket { get; set; }

    [JsonPropertyName("file_hash")] public string Hash { get; set; }
};
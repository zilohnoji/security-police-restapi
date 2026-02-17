using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.Photo.Request;

public sealed class CreatePhotoRequestDto
{
    [JsonPropertyName("bucket")] public string Bucket { get; set; } = string.Empty;

    [JsonPropertyName("file_hash")] public string Hash { get; set; } = string.Empty;
};
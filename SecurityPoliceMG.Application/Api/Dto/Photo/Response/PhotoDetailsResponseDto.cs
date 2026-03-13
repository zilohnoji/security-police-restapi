namespace SecurityPoliceMG.Api.Dto.Photo.Response;

public sealed class PhotoDetailsResponseDto
{
    public DateTime CreatedAt { get; set; }

    public string Bucket { get; set; }

    public string Hash { get; set; }

    private PhotoDetailsResponseDto()
    {
    }

    private PhotoDetailsResponseDto(string bucket, string hash)
    {
        Bucket = bucket;
        Hash = hash;
        CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    }

    public static PhotoDetailsResponseDto Of(string bucket, string hash)
    {
        return new PhotoDetailsResponseDto(bucket, hash);
    }
}
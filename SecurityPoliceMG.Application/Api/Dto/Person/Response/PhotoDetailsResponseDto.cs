namespace SecurityPoliceMG.Api.Dto.Person.Response;

public sealed class PhotoDetailsResponseDto
{
    public DateTime CreatedAt { get; set; }

    public string Bucket { get; set; }

    public string Hash { get; set; }

    public static readonly PhotoDetailsResponseDto Empty = new PhotoDetailsResponseDto();

    private PhotoDetailsResponseDto()
    {
        CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        ;
        Bucket = string.Empty;
        Hash = string.Empty;
    }

    private PhotoDetailsResponseDto(string bucket, string hash)
    {
        Bucket = bucket;
        Hash = hash;
        CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        ;
    }

    public static PhotoDetailsResponseDto Of(string bucket, string hash)
    {
        return new PhotoDetailsResponseDto(bucket, hash);
    }
}
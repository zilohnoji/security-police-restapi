namespace SecurityPoliceMG.Api.Dto.Scale.Response;

public sealed class ScaleDetailsResponseDto
{
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime StartsAt { get; set; }

    public DateTime FinishedAt { get; set; }

    public string Description { get; set; }
}
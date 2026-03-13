using SecurityPoliceMG.Api.Dto.Scale.Response;

namespace SecurityPoliceMG.Api.Dto.Request.Response;

public sealed class CreateRequestExchangeScaleResponseDto
{
    public Guid Id { get; set; }

    public CreateRequestResponseDto Request { get; set; }

    public string Status { get; set; }

    public DateTime AcceptedAt { get; set; }

    public ScaleDetailsResponseDto RequesterScale { get; set; }

    public ScaleDetailsResponseDto ReceiverScale { get; set; }
}
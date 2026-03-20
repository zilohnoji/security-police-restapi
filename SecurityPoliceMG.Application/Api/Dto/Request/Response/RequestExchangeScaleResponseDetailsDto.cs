using SecurityPoliceMG.Api.Dto.Scale.Response;

namespace SecurityPoliceMG.Api.Dto.Request.Response;

public class RequestExchangeScaleResponseDetailsDto
{
    public CreateRequestResponseDto Request { get; set; }

    public string Status { get; set; }

    public ScaleDetailsResponseDto RequesterScale { get; set; }
}
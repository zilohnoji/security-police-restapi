namespace SecurityPoliceMG.Api.Dto.Request.Response;

public sealed class RequestResponseDetailsDto
{
    public Guid Id { get; set; }
    public string Status { get; set; }

    public Guid RequestedBy { get; set; }

    public Guid ReceivedBy { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }
}
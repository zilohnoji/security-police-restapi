using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.Request.Request;

public record CreateRequestDto
{
    [JsonPropertyName("receiver_id")] public string ReceiverId { get; set; } 
    
    [JsonPropertyName("requester_scale_id")] public string RequesterScaleId { get; set; } 

    [JsonPropertyName("description")] public string Description { get; set; }
};
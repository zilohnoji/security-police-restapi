using SecurityPoliceMG.Api.Dto.Request.Response;
using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository.Base;

namespace SecurityPoliceMG.Api.Mapper;

public static class RequestExchangeScaleMapper
{
    public static CreateRequestExchangeScaleResponseDto ToDto(RequestExchangeScale requestExchange)
    {
        return new CreateRequestExchangeScaleResponseDto()
        {
            Request = new CreateRequestResponseDto()
            {
                Id = requestExchange.Request.Id,
                RequestedBy = requestExchange.Request.RequesterId,
                ReceivedBy = requestExchange.Request.ReceiverId,
                Description = requestExchange.Request.Description,
                CreatedAt = requestExchange.Request.CreatedAt,
            },
            Id = requestExchange.Id,
            Status = requestExchange.Status.ToString(),
            RequesterScale = ScaleMapper.ToDto(requestExchange.RequesterScale)
        };
    }
    
    public static RequestResponseDetailsDto ToDtoDetails(RequestExchangeScale requestExchange)
    {
        return new RequestResponseDetailsDto()
        {
            CreatedAt = requestExchange.Request.CreatedAt,
            Description = requestExchange.Request.Description,
            ReceivedBy = requestExchange.Request.ReceiverId,
            RequestedBy = requestExchange.Request.RequesterId,
            Status = requestExchange.Status.ToString()
        };
    }

    public static Page<RequestResponseDetailsDto> ToPageDto(Page<RequestExchangeScale> requestPage)
    {
        var collectionDto = requestPage.Elements.Select(ToDtoDetails).ToList();
        return Page<RequestResponseDetailsDto>.Of(collectionDto, requestPage.Total, requestPage.Pageable);
    }
}
using SecurityPoliceMG.Api.Dto.Request.Request;
using SecurityPoliceMG.Domain.Entity.Enum;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Api.Mapper;

public static class RequestMapper
{
    public static Request ToEntity(CreateRequestDto requestDto, RequestType requestType, Guid loggedUserId)
    {
        return Request.RequestBuilder.Builder()
            .Description(requestDto.Description)
            .ReceiverId(Guid.Parse(requestDto.ReceiverId))
            .RequesterId(loggedUserId)
            .RequestType(requestType)
            .Build();
    }
}
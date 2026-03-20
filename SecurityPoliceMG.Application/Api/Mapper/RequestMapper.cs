using SecurityPoliceMG.Api.Dto.Request.Request;
using SecurityPoliceMG.Api.Dto.Request.Response;
using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.Domain.Entity.Enum;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.Util;

namespace SecurityPoliceMG.Api.Mapper;

public static class RequestMapper
{
    public static Request ToEntity(CreateRequestDto requestDto, RequestType requestType, Guid personId)
    {
        return Request.RequestBuilder.Builder()
            .CreatedAt(DateTime.UtcNow)
            .Description(requestDto.Description)
            .IsCompleted(false)
            .ReceiverId(Guid.Parse(requestDto.ReceiverId))
            .RequesterId(personId)
            .RequestType(requestType)
            .Build();
    }
}
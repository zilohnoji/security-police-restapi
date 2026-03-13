using SecurityPoliceMG.Api.Dto.Request.Request;
using SecurityPoliceMG.Api.Dto.Request.Response;
using SecurityPoliceMG.Api.Mapper;
using SecurityPoliceMG.Domain.Entity.Enum;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository.Impl;

namespace SecurityPoliceMG.Service.Impl;

public class RequestServiceImpl(
    RequestRepositoryImpl requestRepositoryImpl,
    RequestExchangeScaleRepositoryImpl requestExchangeScaleRepositoryImpl) : IRequestService
{
    public CreateRequestExchangeScaleResponseDto CreateRequestForExchangeScale(CreateRequestDto requestDto,
        Guid scaleId, Guid loggedUserId)
    {
        var request = RequestMapper.ToEntity(requestDto, RequestType.Scale, loggedUserId);
        var exchangeScale = RequestExchangeScale.RequestExchangeScaleBuilder.Builder(request)
            .Status(RequestStatus.Pending)
            .RequesterScaleId(Guid.Parse(requestDto.RequesterScaleId))
            .ReceiverScaleId(null)
            .Build();

        request = requestRepositoryImpl.Create(request);
        exchangeScale = request.RequestExchangeScale;

        return new CreateRequestExchangeScaleResponseDto()
        {
            Request = new CreateRequestResponseDto()
            {
                Id = request.Id,
                RequestedBy = request.RequesterId,
                ReceivedBy = request.ReceiverId,
                Description = request.Description,
                CreatedAt = request.CreatedAt,
                RequestType = request.RequestType.ToString()
            },
            Id = exchangeScale.Id,
            Status = exchangeScale.Status.ToString(),
            AcceptedAt = exchangeScale.AcceptedAt,
            RequesterScale = ScaleMapper.ToDto(exchangeScale.RequesterScale)
        };
    }
}
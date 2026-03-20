using SecurityPoliceMG.Api.Dto.Request.Request;
using SecurityPoliceMG.Api.Dto.Request.Response;
using SecurityPoliceMG.Api.Mapper;
using SecurityPoliceMG.Domain.Entity.Enum;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.EFCore.Repository.Impl;

namespace SecurityPoliceMG.Service.Impl.RequestModule;

public class RequestServiceImpl(
    RequestRepositoryImpl requestRepositoryImpl,
    RequestExchangeScaleRepositoryImpl requestExchangeScaleRepositoryImpl,
    UserRepositoryImpl userRepositoryImpl,
    ScaleRepositoryImpl scaleRepositoryImpl) : IRequestService
{
    public CreateRequestExchangeScaleResponseDto CreateRequestForExchangeScale(CreateRequestDto requestDto,
        Guid scaleId, Guid loggedUserId)
    {
        var userLoggedEntity = userRepositoryImpl.FindById(loggedUserId);

        if (userLoggedEntity.Person is null)
        {
            throw new ArgumentException("Esse usuário não tem um cadastro com seus dados pessoais!!");
        }

        var requestEntity = RequestMapper.ToEntity(requestDto, RequestType.Scale, userLoggedEntity.Person.Id);

        requestEntity = requestRepositoryImpl.Create(requestEntity);

        var requestExchangeScaleEntity = RequestExchangeScale.RequestExchangeScaleBuilder.Builder(requestEntity)
            .Status(RequestStatus.Pending)
            .RequesterScaleId(scaleId)
            .ReceiverScaleId(null)
            .Build();

        requestExchangeScaleEntity = requestExchangeScaleRepositoryImpl.Create(requestExchangeScaleEntity);

        requestExchangeScaleEntity = requestExchangeScaleRepositoryImpl.FindById(requestExchangeScaleEntity.Id);

        return RequestExchangeScaleMapper.ToDto(requestExchangeScaleEntity);
    }

    public Page<RequestResponseDetailsDto> GetMyPendingSentRequests(Pageable pageable, Guid loggedUserId)
    {
        var userLoggedEntity = userRepositoryImpl.FindById(loggedUserId);

        pageable.SearchTerm = "pending";

        if (userLoggedEntity.Person is null)
        {
            throw new ArgumentException("Esse usuário não tem um cadastro com seus dados pessoais!!");
        }

        var requestsExchange =
            requestExchangeScaleRepositoryImpl.GetAllPendingSendRequests(pageable, userLoggedEntity.Person.Id);

        return RequestExchangeScaleMapper.ToPageDto(requestsExchange);
    }

    public Page<RequestResponseDetailsDto> GetMyPendingReceivedRequests(Pageable pageable, Guid loggedUserId)
    {
        var userLoggedEntity = userRepositoryImpl.FindById(loggedUserId);

        pageable.SearchTerm = "pending";

        if (userLoggedEntity.Person is null)
        {
            throw new ArgumentException("Esse usuário não tem um cadastro com seus dados pessoais!!");
        }

        var requestsExchange =
            requestExchangeScaleRepositoryImpl.GetAllPendingReceivedRequests(pageable, userLoggedEntity.Person.Id);

        return RequestExchangeScaleMapper.ToPageDto(requestsExchange);
    }

    public RequestResponseDetailsDto AcceptRequestExchangeScale(Guid requestExchangeScaleId,
        Guid receiverScaleId,
        Guid loggedUserId)
    {
        var userLoggedEntity = userRepositoryImpl.FindById(loggedUserId);
        var requestExchangeScaleEntity = requestExchangeScaleRepositoryImpl.FindById(requestExchangeScaleId);
        var scaleReceiverEntity = scaleRepositoryImpl.FindById(receiverScaleId);

        if (requestExchangeScaleEntity is null)
        {
            throw new ArgumentException($"A solicitação de ID {requestExchangeScaleId} não existe!!");
        }

        if (userLoggedEntity.Person is null)
        {
            throw new ArgumentException("Esse usuário não tem um cadastro com seus dados pessoais!!");
        }

        if (!userLoggedEntity.Person.ReceiveRequests.Any(p => p.Id == requestExchangeScaleEntity.RequestId))
        {
            throw new ArgumentException("Essa solicitação não foi atribuída a você!!");
        }

        if (scaleReceiverEntity is null)
        {
            throw new ArgumentException($"A escala de ID {receiverScaleId} não existe!!");
        }

        requestExchangeScaleEntity = RequestExchangeScale.RequestExchangeScaleBuilder
            .Builder(requestExchangeScaleEntity.Request, requestExchangeScaleEntity)
            .Status(RequestStatus.Accepted)
            .AcceptedAt(DateTime.UtcNow)
            .ReceiverScaleId(receiverScaleId)
            .Build();

        requestExchangeScaleEntity = requestExchangeScaleRepositoryImpl.Update(requestExchangeScaleEntity);


        return RequestExchangeScaleMapper.ToDtoDetails(requestExchangeScaleEntity);
    }
}
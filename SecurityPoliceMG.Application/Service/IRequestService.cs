using SecurityPoliceMG.Api.Dto.Request.Request;
using SecurityPoliceMG.Api.Dto.Request.Response;
using SecurityPoliceMG.EFCore.Repository.Base;

namespace SecurityPoliceMG.Service;

public interface IRequestService
{
    CreateRequestExchangeScaleResponseDto CreateRequestForExchangeScale(CreateRequestDto requestDto, Guid scaleId, Guid loggedUserId);

    Page<RequestResponseDetailsDto> GetMyPendingSentRequests(Pageable pageable, Guid loggedUserId);

    Page<RequestResponseDetailsDto> GetMyPendingReceivedRequests(Pageable pageable, Guid loggedUserId);
    
    RequestResponseDetailsDto AcceptRequestExchangeScale(Guid requestExchangeScaleId, Guid receiverScaleId, Guid loggedUserId);
}
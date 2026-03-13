using SecurityPoliceMG.Api.Dto.Request.Request;
using SecurityPoliceMG.Api.Dto.Request.Response;

namespace SecurityPoliceMG.Service;

public interface IRequestService
{
    CreateRequestExchangeScaleResponseDto CreateRequestForExchangeScale(CreateRequestDto requestDto, Guid scaleId,
        Guid loggedUserId);
}
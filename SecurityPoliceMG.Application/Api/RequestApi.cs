using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SecurityPoliceMG.Api.Base;
using SecurityPoliceMG.Api.Dto.Request.Request;
using SecurityPoliceMG.Domain.Entity.Enum;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.Service;

namespace SecurityPoliceMG.Api;

[ApiController]
[Route("/api/requests")]
[EnableCors("LocalPolicy")]
public class RequestApi(IRequestService service) : BaseController
{
    [Authorize]
    [HttpPost("scales/{scaleId:guid}/exchange")]
    public IActionResult CreateRequestExchangeScale([FromBody] CreateRequestDto requestDto, [FromRoute] Guid scaleId)
    {
        var response = service.CreateRequestForExchangeScale(requestDto, scaleId, GetLoggedUserId());
        return Created($"{response.Id}", response);
    }

    [Authorize]
    [HttpGet("scales/sent-exchange")]
    public IActionResult GetMyPendingSentRequests([FromQuery] Pageable pageable)
    {
        return Ok(service.GetMyPendingSentRequests(pageable, GetLoggedUserId()));
    }

    [Authorize]
    [HttpGet("scales/received-exchange")]
    public IActionResult GetMyPendingReceivedRequests([FromQuery] Pageable pageable)
    {
        return Ok(service.GetMyPendingReceivedRequests(pageable, GetLoggedUserId()));
    }

    [Authorize(Roles = nameof(UserRole.Agent))]
    [HttpPost("scales/{requestExchangeScaleId:guid}/accept-exchange/{receiverExchangeScaleId:guid}")]
    public IActionResult AcceptRequestExchangeScale([FromRoute] Guid requestExchangeScaleId,
        [FromRoute] Guid receiverScaleId)
    {
        return Ok(service.AcceptRequestExchangeScale(requestExchangeScaleId, receiverScaleId, GetLoggedUserId()));
    }
}
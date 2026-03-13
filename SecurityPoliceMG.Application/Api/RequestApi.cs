using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SecurityPoliceMG.Api.Base;
using SecurityPoliceMG.Api.Dto.Request.Request;
using SecurityPoliceMG.Domain.Entity.Enum;
using SecurityPoliceMG.Service;

namespace SecurityPoliceMG.Api;

[ApiController]
[Route("/api/requests")]
[EnableCors("LocalPolicy")]
public class RequestApi(IRequestService service) : BaseController
{
    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPost("scales/{scaleId:guid}/exchange")]
    public IActionResult OpenRequestExchangeScale(
        [FromBody] CreateRequestDto requestDto, [FromRoute] Guid scaleId)
    {
        service.CreateRequestForExchangeScale(requestDto, scaleId, GetLoggedUserId());
        return Created();
    }
}
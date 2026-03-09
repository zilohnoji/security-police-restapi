using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SecurityPoliceMG.Api.Base;
using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.Authentication.Configuration.Enum;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.Service;

namespace SecurityPoliceMG.Api;

[ApiController]
[Route("/api/scales")]
[EnableCors("LocalPolicy")]
[Authorize(nameof(SecurityPolicy.ActiveUserOnly))]
public class ScaleApi(IScaleService service) : GenericApi
{
    [HttpPost("{personId:guid}")]
    public IActionResult CreateScale([FromRoute] Guid personId, [FromBody] CreateScaleRequestDto requestDto)
    {
        ScaleDetailsResponseDto response = service.CreateScale(personId, requestDto);
        return Created(response.Id.ToString(), response);
    }

    [HttpGet]
    public IActionResult FindAll(
        [FromQuery] int? page,
        [FromQuery] int? pageSize,
        [FromQuery] string? sort,
        [FromQuery] string? orderTerm,
        [FromQuery] string? searchTerm)
    {
        var pageable = Pageable.Of(page, pageSize, sort, orderTerm, searchTerm);
        return Ok(service.FindAll(pageable));
    }
}
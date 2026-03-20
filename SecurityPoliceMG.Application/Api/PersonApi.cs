using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SecurityPoliceMG.Api.Base;
using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.Service;

namespace SecurityPoliceMG.Api;

[Authorize]
[ApiController]
[Route("api/persons")]
[EnableCors("LocalPolicy")]
public sealed class PersonApi(IPersonService service) : BaseController
{
    [HttpPost]
    public IActionResult Create([FromBody] CreatePersonRequestDto requestDto)
    {
        PersonDetailsResponseDto response = service.Create(requestDto, GetLoggedUserId());
        return Created(response.Id.ToString(), response);
    }

    [HttpGet]
    public IActionResult FindAll([FromQuery] Pageable pageable)
    {
        return Ok(service.FindAll(pageable));
    }
}
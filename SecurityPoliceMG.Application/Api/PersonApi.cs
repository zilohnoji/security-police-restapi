using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Service;

namespace SecurityPoliceMG.Api;

[Authorize]
[ApiController]
[Route("api/persons")]
[EnableCors("LocalPolicy")]
public sealed class PersonApi(IPersonService service) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<PersonDetailsResponseDto>(201)]
    public ActionResult<PersonDetailsResponseDto> Create([FromBody] CreatePersonRequestDto requestDto)
    {
        PersonDetailsResponseDto response = service.Create(requestDto);
        return Created(response.Id.ToString(), response);
    }

    [HttpGet]
    [ProducesResponseType<PersonDetailsResponseDto[]>(200)]
    public ActionResult<List<PersonDetailsResponseDto>> FindAll()
    {
        return Ok(service.FindAll());
    }

    [HttpPost("scale")]
    [ProducesResponseType<PersonDetailsResponseDto>(201)]
    public ActionResult<PersonDetailsResponseDto> CreateScale([FromBody] CreateScaleRequestDto requestDto)
    {
        PersonDetailsResponseDto response = service.CreateScale(requestDto);
        return Created(response.Id.ToString(), response);
    }
}
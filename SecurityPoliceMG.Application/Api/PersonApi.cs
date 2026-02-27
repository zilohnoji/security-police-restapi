using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SecurityPoliceMG.Api.Base;
using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.Service;

namespace SecurityPoliceMG.Api;

[ApiController]
[Route("api/persons")]
[EnableCors("LocalPolicy")]
[Authorize(Policy = "ActiveUserOnly")]
public sealed class PersonApi(IPersonService service) : GenericApi
{
    [HttpPost]
    public IActionResult Create([FromBody] CreatePersonRequestDto requestDto)
    {
        PersonDetailsResponseDto response = service.Create(requestDto, GetLoggedUserId());
        return Created(response.Id.ToString(), response);
    }

    [HttpGet]
    public IActionResult FindAll(
        [FromQuery] int? page,
        [FromQuery] int? pageSize,
        [FromQuery] string? sort,
        [FromQuery] string? searchTerm)
    {
        var pageable = Pageable.Of(page, pageSize, sort, searchTerm);
        return Ok(service.FindAll(pageable));
    }


    // TODO Criar um controller para a Scale

    [HttpPost("scale")]
    public IActionResult CreateScale([FromBody] CreateScaleRequestDto requestDto)
    {
        PersonDetailsResponseDto response = service.CreateScale(requestDto);
        return Created(response.Id.ToString(), response);
    }
}
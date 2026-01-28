using Microsoft.AspNetCore.Mvc;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Dto.Person.Request;
using SecurityPoliceMG.Service;

namespace SecurityPoliceMG.Api;

[ApiController]
[Route("api/persons")]
public sealed class PersonApi : ControllerBase
{
    private readonly IPersonService _service;

    public PersonApi(IPersonService service)
    {
        _service = service;
    }

    [HttpPost]
    public ActionResult<CreatePersonResponseDto> Create([FromBody] CreatePersonRequestDto requestDto)
    {
        CreatePersonResponseDto response = _service.Create(requestDto);
        return Created(response.Id.ToString(), response);
    }

    [HttpGet]
    public ActionResult<List<CreatePersonResponseDto>> FindAll()
    {
        return Ok(_service.FindAll());
    }
}
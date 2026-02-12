using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SecurityPoliceMG.Api.Dto.User.Request;
using SecurityPoliceMG.Service;

namespace SecurityPoliceMG.Api;

[ApiController]
[Route("api/auth")]
[EnableCors("LocalPolicy")]
public sealed class UserAuthApi(IUserAuthService service) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("signin")]
    public IActionResult Signin([FromBody] AuthenticationUserRequestDto requestDto)
    {
        return Ok(service.Signin(requestDto));
    }

    [AllowAnonymous]
    [HttpPost("signinup")]
    public IActionResult SigninUp([FromBody] CreateUserRequestDto requestDto)
    {
        var response = service.SigninUp(requestDto);
        return Created($"{response.Id}", response);
    }

    [AllowAnonymous]
    [HttpPost("access-token")]
    public IActionResult ProducesAccessToken([FromHeader(Name = "Refresh-Token")] string refreshToken)
    {
        return Ok(service.ProducesAccessToken(refreshToken));
    }
}
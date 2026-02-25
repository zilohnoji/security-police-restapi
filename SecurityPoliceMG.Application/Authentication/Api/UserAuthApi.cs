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
    [HttpPost("sign-in")]
    public IActionResult Signin([FromBody] AuthenticationUserRequestDto requestDto)
    {
        return Ok(service.Signin(requestDto));
    }

    [AllowAnonymous]
    [HttpPost("signin-up")]
    public IActionResult SigninUp([FromBody] CreateUserRequestDto requestDto)
    {
        var response = service.SigninUp(requestDto);
        return Created($"{response.Id}", response);
    }

    [AllowAnonymous]
    [HttpPost("refresh-token")]
    public IActionResult ValidateCredentials([FromBody] RefreshTokenRequestDto requestDto)
    {
        return Ok(service.RefreshAccessToken(requestDto));
    }

    [AllowAnonymous]
    [HttpPost("{userEmail}/active/{emailCode}")]
    public IActionResult ActiveAccount([FromRoute] string userEmail, [FromRoute] string emailCode)
    {
        return Ok(service.ActiveAccount(userEmail, emailCode));
    }
}
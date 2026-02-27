using SecurityPoliceMG.Api.Dto.User.Request;
using SecurityPoliceMG.Api.Dto.User.Response;

namespace SecurityPoliceMG.Authentication.Service;

public interface IUserAuthService
{
    TokenUserResponseDto? Signin(AuthenticationUserRequestDto requestDto);
    
    CreateUserResponseDto SigninUp(CreateUserRequestDto requestDto);
    
    TokenUserResponseDto RefreshAccessToken(RefreshTokenRequestDto requestDto);

    CreateUserResponseDto ActiveAccount(string userEmail, string emailCode);
}
using SecurityPoliceMG.Api.Dto.Request;
using SecurityPoliceMG.Api.Dto.Response;
using SecurityPoliceMG.Api.Dto.User.Request;
using SecurityPoliceMG.Api.Dto.User.Response;

namespace SecurityPoliceMG.Service;

public interface IUserAuthService
{
    CreateUserResponseDto SigninUp(CreateUserRequestDto requestDto);

    TokenUserResponseDto? Signin(AuthenticationUserRequestDto requestDto);

    bool RevokeToken(string email);

    string ValidateCredentials(RefreshTokenRequestDto requestDto);

    // User UpdateData(User user);
}
using SecurityPoliceMG.Api.Dto.Response;
using SecurityPoliceMG.Api.Dto.User.Request;
using SecurityPoliceMG.Api.Dto.User.Response;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Service;

public interface IUserAuthService
{
    User? FindByEmail(string email);

    CreateUserResponseDto SigninUp(CreateUserRequestDto requestDto);

    AuthenticationUserResponseDto? Signin(AuthenticationUserRequestDto requestDto);

    bool RevokeToken(string email);

    string ProducesAccessToken(string refreshToken);

    // User UpdateData(User user);
}
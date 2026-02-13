using SecurityPoliceMG.Api.Dto.Request;
using SecurityPoliceMG.Api.Dto.Response;
using SecurityPoliceMG.Api.Dto.User.Request;
using SecurityPoliceMG.Api.Dto.User.Response;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Service;

public interface IUserAuthService
{
    CreateUserResponseDto SigninUp(CreateUserRequestDto requestDto);

    TokenUserResponseDto? Signin(AuthenticationUserRequestDto requestDto);

    User? GetLoggedUser();
    
    bool RevokeToken(string email);

    TokenUserResponseDto ValidateCredentials(RefreshTokenRequestDto requestDto);

    // User UpdateData(User user);
}
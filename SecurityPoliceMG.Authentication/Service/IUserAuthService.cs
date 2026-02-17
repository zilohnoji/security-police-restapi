using SecurityPoliceMG.Api.Dto.User.Request;
using SecurityPoliceMG.Api.Dto.User.Response;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Service;

public interface IUserAuthService
{
    TokenUserResponseDto? Signin(AuthenticationUserRequestDto requestDto);
    
    CreateUserResponseDto SigninUp(CreateUserRequestDto requestDto);
    
    TokenUserResponseDto RefreshAccessToken(RefreshTokenRequestDto requestDto);
    
    User GetLoggedUser(Guid userId);
}
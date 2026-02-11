using SecurityPoliceMG.Api.Dto.User.Request;
using SecurityPoliceMG.Api.Dto.User.Response;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Service;

public interface IUserAuthService
{
    User? FindByEmail(string email);

    CreateUserResponseDto Register(CreateUserRequestDto requestDto);

    bool RevokeToken(string email);

    AuthenticationUserResponseDto? ValidateCredentials(AuthenticationUserRequestDto requestDto);

    // User UpdateData(User user);
}
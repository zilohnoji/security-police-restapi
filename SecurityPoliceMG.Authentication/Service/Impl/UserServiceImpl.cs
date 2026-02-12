using SecurityPoliceMG.Api.Dto.Response;
using SecurityPoliceMG.Api.Dto.User.Request;
using SecurityPoliceMG.Api.Dto.User.Response;
using SecurityPoliceMG.Contract;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository.Impl;

namespace SecurityPoliceMG.Service.Impl;

public class UserServiceImpl(
    UserRepositoryImpl repositoryImpl,
    IPasswordEncoder passwordEncoder,
    ITokenGenerator tokenGenerator) : IUserAuthService
{
    public AuthenticationUserResponseDto? Signin(AuthenticationUserRequestDto requestDto)
    {
        var entity = repositoryImpl.FindByEmail(requestDto.Email);

        if (entity is null || !passwordEncoder.MatchPassword(requestDto.Password, entity.Password))
        {
            throw new ArgumentException("Senha inválida");
        }

        var accessToken = tokenGenerator.GenerateAccessToken(entity);
        var refreshToken = RefreshToken.Of(32);

        entity.DefineRefreshToken(refreshToken);
        repositoryImpl.Update(entity);

        return new AuthenticationUserResponseDto()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token
        };
    }

    public CreateUserResponseDto SigninUp(CreateUserRequestDto requestDto)
    {
        if (repositoryImpl.ExistsByEmail(requestDto.Email))
        {
            throw new ArgumentException("Esse email já está sendo usado!!");
        }

        var entity = User.Of(requestDto.Email, passwordEncoder.Encode(requestDto.Password), null);
        entity = repositoryImpl.Create(entity);

        return CreateUserResponseDto.Of(entity.Id.ToString(), entity.Email);
    }

    public string ProducesAccessToken(string refreshToken)
    {
        var entity = repositoryImpl.FindByRefreshToken(refreshToken);

        if (entity?.RefreshToken is null)
        {
            throw new ArgumentException("Refresh token inválido!");
        }

        if (entity.RefreshToken.ExpiryTime < DateTime.Now)
        {
            throw new ArgumentException("O refresh token está expirado!");
        }

        var accessToken = tokenGenerator.GenerateAccessToken(entity);
        return accessToken;
    }

    public bool RevokeToken(string email)
    {
        if (!repositoryImpl.ExistsByEmail(email))
        {
            return false;
        }

        var entity = repositoryImpl.FindByEmail(email);
        entity.RevokeRefreshToken();
        repositoryImpl.Update(entity);
        return true;
    }
}
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
    public User? FindByEmail(string email)
    {
        return repositoryImpl.FindByEmail(email);
    }

    public AuthenticationUserResponseDto? Signin(AuthenticationUserRequestDto requestDto)
    {
        var entity = FindByEmail(requestDto.Email);

        if (entity is null || !passwordEncoder.MatchPassword(requestDto.Password, entity.Password))
        {
            throw new ArgumentException("Senha inválida");
        }

        var accessToken = tokenGenerator.GenerateAccessToken(entity);
        var refreshToken = tokenGenerator.GenerateRefreshToken();

        entity.DefineRefreshToken(refreshToken, DateTime.Now.AddDays(7));
        repositoryImpl.Update(entity);

        return new AuthenticationUserResponseDto()
        {
            AccessToken = accessToken,
            RefreshToken = entity.RefreshToken
        };
    }

    public CreateUserResponseDto SigninUp(CreateUserRequestDto requestDto)
    {
        if (FindByEmail(requestDto.Email) != null)
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

        if (entity is null || entity.RefreshTokenExpiryTime < DateTime.Now)
        {
            throw new ArgumentException("O refresh token está expirado!");
        }

        var accessToken = tokenGenerator.GenerateAccessToken(entity);
        return accessToken;
    }

    public bool RevokeToken(string email)
    {
        var entity = FindByEmail(email);
        if (entity == null)
        {
            return false;
        }

        entity.DefineRefreshToken(null);
        repositoryImpl.Update(entity);

        return true;
    }
}
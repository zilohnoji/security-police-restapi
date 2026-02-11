using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
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

    public CreateUserResponseDto Register(CreateUserRequestDto requestDto)
    {
        if (FindByEmail(requestDto.Email) != null)
        {
            throw new ArgumentException("Esse email já está sendo usado!!");
        }

        var entity = User.Of(requestDto.Email, passwordEncoder.Encode(requestDto.Password), null);
        entity = repositoryImpl.Create(entity);

        return CreateUserResponseDto.Of(entity.Id.ToString(), entity.Email);
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

    public AuthenticationUserResponseDto? ValidateCredentials(AuthenticationUserRequestDto requestDto)
    {
        var entity = FindByEmail(requestDto.Email);
        if (entity == null ||
            !passwordEncoder.MatchPassword(requestDto.Password, entity.Password))
        {
            throw new ArgumentException("Senha inválida");
        }

        Claim[] claims =
        [
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N"))
        ];

        var accessToken = tokenGenerator.GenerateAccessToken(claims);
        var refreshToken = tokenGenerator.GenerateRefreshToken();

        entity.DefineRefreshToken(refreshToken, DateTime.Now.AddDays(7));
        entity = repositoryImpl.Update(entity);

        return new AuthenticationUserResponseDto()
        {
            Email = entity.Email,
            Authenticated = true,
            RefreshToken = refreshToken,
            AccessToken = accessToken
        };
    }
}
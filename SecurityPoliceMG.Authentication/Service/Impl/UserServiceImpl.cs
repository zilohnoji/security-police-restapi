using SecurityPoliceMG.Api.Dto.User.Request;
using SecurityPoliceMG.Api.Dto.User.Response;
using SecurityPoliceMG.Configuration.Security;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository;
using SecurityPoliceMG.EFCore.Repository.Impl;

namespace SecurityPoliceMG.Service.Impl;

public class UserServiceImpl(
    UserRepositoryImpl repositoryImpl,
    IRepository<EmailCodeConfirmation> emailCodeRepository,
    IPasswordEncoder passwordEncoder,
    ITokenGenerator tokenGenerator) : IUserAuthService
{
    public TokenUserResponseDto Signin(AuthenticationUserRequestDto requestDto)
    {
        var entity = repositoryImpl.FindByEmailOrThrowNotFound(requestDto.Email);

        if (!entity.IsActive)
        {
            throw new ArgumentException("Usuário não ativado, verifique seu email");
        }

        if (!passwordEncoder.VerifyPassword(requestDto.Password, entity.Password))
        {
            throw new ArgumentException("Senha inválida");
        }

        var accessToken = tokenGenerator.GenerateAccessToken(entity);
        var refreshToken = RefreshToken.Of(32);

        entity.DefineRefreshToken(refreshToken);
        repositoryImpl.Update(entity);

        return TokenUserResponseDto.Of(accessToken, refreshToken.Token);
    }

    public CreateUserResponseDto SigninUp(CreateUserRequestDto requestDto)
    {
        if (repositoryImpl.ExistsByEmail(requestDto.Email))
        {
            throw new ArgumentException("Esse email já está sendo usado!!");
        }

        var emailCode = EmailCodeConfirmation.Of(DateTime.UtcNow.AddMinutes(30));
        var entity = User.Of(requestDto.Email, passwordEncoder.Encode(requestDto.Password), emailCode);

        entity = repositoryImpl.Create(entity);

        return CreateUserResponseDto.Of(entity.Id.ToString(), entity.Email);
    }

    public TokenUserResponseDto RefreshAccessToken(RefreshTokenRequestDto requestDto)
    {
        var email = tokenGenerator.GetUsernameFromExpiredAccessToken(requestDto.ExpiredAccessToken);

        var entity = repositoryImpl.FindByEmail(email);

        if (entity?.RefreshToken is null)
        {
            throw new ArgumentException("Usuário não possui um refresh token, autenticação necessária!");
        }

        if (!entity.RefreshToken.Token.Equals(requestDto.RefreshToken))
        {
            throw new ArgumentException("Refresh token inválido");
        }

        if (entity.RefreshToken.ExpiryTime < DateTime.UtcNow)
        {
            throw new ArgumentException("O refresh token está expirado!");
        }

        entity.DefineRefreshToken(RefreshToken.Of(32));
        entity = repositoryImpl.Update(entity);

        return TokenUserResponseDto.Of(tokenGenerator.GenerateAccessToken(entity), entity?.RefreshToken.Token);
    }

    public User GetLoggedUser(Guid userId)
    {
        return repositoryImpl.FindById(userId) ?? throw new ArgumentException("Usuário não autenticado!");
    }
}
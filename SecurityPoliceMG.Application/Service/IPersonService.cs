using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.EFCore.Repository.Base;

namespace SecurityPoliceMG.Service;

public interface IPersonService
{
    PersonDetailsResponseDto Create(CreatePersonRequestDto requestDto, Guid loggedUserId);

    // PersonDetailsResponseDto FindById(Guid personId);

    Page<PersonDetailsResponseDto> FindAll(Pageable pageable);
}
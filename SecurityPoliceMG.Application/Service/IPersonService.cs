using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Api.Dto.Person.Request;

namespace SecurityPoliceMG.Service;

public interface IPersonService
{
    PersonDetailsResponseDto Create(CreatePersonRequestDto requestDto);

    List<PersonDetailsResponseDto> FindAll();
}
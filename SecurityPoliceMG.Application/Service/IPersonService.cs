using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Api.Dto.Scale.Request;

namespace SecurityPoliceMG.Service;

public interface IPersonService
{
    PersonDetailsResponseDto Create(CreatePersonRequestDto requestDto);

    List<PersonDetailsResponseDto> FindAll();

    PersonDetailsResponseDto CreateScale(CreateScaleRequestDto responseDto);
}
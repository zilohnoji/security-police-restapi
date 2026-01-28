using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Dto.Person.Request;

namespace SecurityPoliceMG.Service;

public interface IPersonService
{
    CreatePersonResponseDto Create(CreatePersonRequestDto requestDto);

    List<CreatePersonResponseDto> FindAll();
}
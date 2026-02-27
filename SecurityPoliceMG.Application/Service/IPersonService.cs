using System.Linq.Expressions;
using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository.Base;

namespace SecurityPoliceMG.Service;

public interface IPersonService
{
    PersonDetailsResponseDto Create(CreatePersonRequestDto requestDto, Guid loggedUserId);

    PersonDetailsResponseDto CreateScale(CreateScaleRequestDto responseDto);

    Page<PersonDetailsResponseDto> FindAll(Pageable pageable);
}
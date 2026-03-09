using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Api.Mapper;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.EFCore.Repository.Impl;

namespace SecurityPoliceMG.Service.Impl;

public class PersonServiceImpl(
    PersonRepositoryImpl personRepository,
    UserRepositoryImpl userRepository)
    : IPersonService
{
    public Page<PersonDetailsResponseDto> FindAll(Pageable pageable)
    {
        return PersonMapper.ToPageDto(personRepository.FindAllInclude(pageable));
    }

    public PersonDetailsResponseDto Create(CreatePersonRequestDto requestDto, Guid loggedUserId)
    {
        var personEntity = PersonMapper.ToEntity(requestDto, userRepository.FindById(loggedUserId));
        
        personRepository.Create(personEntity);

        return PersonMapper.ToDto(personEntity);
    }
}
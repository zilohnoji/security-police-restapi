using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Api.Mapper;
using SecurityPoliceMG.Domain.Entity.Model;
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
        var personEntity = userRepository.FindById(loggedUserId).Person;

        if (personEntity is not null) throw new ArgumentException("Esse usuário já possui um cadastro de pessoa!");

        personEntity = PersonMapper.ToEntity(requestDto, userRepository.FindById(loggedUserId));

        personRepository.Create(personEntity);

        return PersonMapper.ToDto(personEntity);
    }
}
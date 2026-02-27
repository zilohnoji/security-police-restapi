using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Api.Mapper;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.EFCore.Repository.Impl;

namespace SecurityPoliceMG.Service.Impl;

public class PersonServiceImpl(
    PersonRepositoryImpl personRepository,
    IRepository<Scale> scaleRepository,
    UserRepositoryImpl userRepositoryImpl)
    : IPersonService
{
    public Page<PersonDetailsResponseDto> FindAll(Pageable pageable)
    {
        return PersonMapper.ToPageDto(personRepository.FindAllInclude(pageable));
    }

    public PersonDetailsResponseDto Create(CreatePersonRequestDto requestDto, Guid loggedUserId)
    {
        var personEntity = PersonMapper.ToEntity(requestDto, userRepositoryImpl.FindById(loggedUserId));

        personRepository.Create(personEntity);

        return PersonMapper.ToDto(personEntity);
    }

    public PersonDetailsResponseDto CreateScale(CreateScaleRequestDto requestDto)
    {
        Person personEntity = personRepository.FindById(Guid.Parse(requestDto.PersonId));
        Scale scaleEntity = ScaleMapper.ToEntity(requestDto, personEntity);

        scaleEntity.PersonScales.Add(PersonScale.Of(scaleEntity, personEntity, 0));

        scaleRepository.Create(scaleEntity);

        PersonDetailsResponseDto responseDto = PersonMapper.ToDto(personEntity);
        responseDto.Scales.Add(ScaleMapper.ToDto(scaleEntity));

        return responseDto;
    }
}
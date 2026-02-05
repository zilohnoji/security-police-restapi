using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Api.Mapper;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository;

namespace SecurityPoliceMG.Service.Impl;

public class PersonServiceImpl(IRepository<Person> personRepository, IRepository<Scale> scaleRepository)
    : IPersonService
{
    public PersonDetailsResponseDto Create(CreatePersonRequestDto requestDto)
    {
        City cityEntity = CityMapper.ToEntity(requestDto.Address.City);

        Address addressEntity = AddressMapper.ToEntity(requestDto.Address, cityEntity);

        Photo photoEntity = PhotoMapper.ToEntity(requestDto.Profile.Photo);

        User userEntity = User.Of(requestDto.User.Email, requestDto.User.Password);

        Person personEntity = PersonMapper.ToEntity(requestDto, userEntity);

        personEntity.DefinePhoto(photoEntity);
        personEntity.DefineUser(userEntity);
        personEntity.DefineAddress(addressEntity);

        personRepository.Create(personEntity);

        return PersonMapper.ToDto(personEntity);
    }

    public List<PersonDetailsResponseDto> FindAll()
    {
        return personRepository.FindAll().Select(PersonMapper.ToDto).ToList();
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
using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Api.Mapper;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository;

namespace SecurityPoliceMG.Service.Impl;

public class PersonServiceImpl(
    IRepository<Person> personRepository,
    IRepository<Address> addressRepository,
    IRepository<Photo> photoRepository,
    IRepository<City> cityRepository) : IPersonService
{
    public PersonDetailsResponseDto Create(CreatePersonRequestDto requestDto)
    {
        City cityEntity = cityRepository.Create(CityMapper.ToEntity(requestDto.Address.City));

        Address addressEntity = addressRepository.Create(AddressMapper.ToEntity(requestDto.Address, cityEntity));

        Person personEntity = personRepository.Create(PersonMapper.ToEntity(requestDto));

        Photo photoEntity = photoRepository.Create(PhotoMapper.ToEntity(requestDto.Photo, personEntity));

        return PersonMapper.ToDto(personEntity, addressEntity, photoEntity);
    }

    public List<PersonDetailsResponseDto> FindAll()
    {
        List<Photo> photoDto = photoRepository.FindAll().ToList();
        List<Address> addressDto = addressRepository.FindAll().ToList();
        List<City> cityDto = cityRepository.FindAll().ToList();

        List<PersonDetailsResponseDto> personDtos =
            personRepository.FindAll().Select(entity =>
            {
                Photo photoEntity = photoDto.Find(t => t.PersonId.Equals(entity.Id)) ?? Photo.Empty;
                Address addressEntity = addressDto.Find(t => t.Id.Equals(entity.AddressId)) ?? Address.Empty;
                City cityEntity = cityDto.Find(t => t.Id.Equals(entity.Address.CityId)) ?? City.Empty;
                return PersonMapper.ToDto(entity, addressEntity, photoEntity);
            }).ToList();

        return personDtos;
    }
}
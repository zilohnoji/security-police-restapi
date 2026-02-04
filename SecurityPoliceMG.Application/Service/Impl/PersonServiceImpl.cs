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
    IRepository<City> cityRepository,
    IRepository<User> userRepository) : IPersonService
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
        List<Photo> photoDto = photoRepository.FindAll().ToList();
        List<Address> addressDto = addressRepository.FindAll().ToList();
        List<City> cityDto = cityRepository.FindAll().ToList();
        List<User> userDto = userRepository.FindAll().ToList();

        List<PersonDetailsResponseDto> personDtos =
            personRepository.FindAll().Select(entity =>
            {
                Photo photoEntity = photoDto.Find(t => t.PersonId.Equals(entity.Id)) ?? Photo.Empty;
                Address addressEntity = addressDto.Find(t => t.Id.Equals(entity.AddressId)) ?? Address.Empty;
                City cityEntity = cityDto.Find(t => t.Id.Equals(entity.Address.CityId)) ?? City.Empty;
                User userEntity = userDto.Find(t => t.Id.Equals(entity.UserId)) ?? User.Empty;

                addressEntity.DefineCity(cityEntity);

                entity.DefinePhoto(photoEntity);
                entity.DefineAddress(addressEntity);
                entity.DefineUser(userEntity);

                return PersonMapper.ToDto(entity);
            }).ToList();

        return personDtos;
    }
}
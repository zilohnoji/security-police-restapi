using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.Util;

namespace SecurityPoliceMG.Api.Mapper;

public static class PersonMapper
{
    public static Person ToEntity(CreatePersonRequestDto requestDto, Guid addressId, Guid userId)
    {
        return Person.PersonBuilder.Builder()
            .Name(requestDto.Profile.Name)
            .Gender(requestDto.Profile.Gender)
            .AddressId(addressId)
            .UserId(userId)
            .BirthDate(DateParser.ParseDateOnly(requestDto.Profile.BirthDate))
            .DaddyName(requestDto.Profile.DaddyName)
            .MotherName(requestDto.Profile.MotherName)
            .Build();
    }

    public static Page<PersonDetailsResponseDto> ToPageDto(Page<Person> personPage)
    {
        var collectionDto = personPage.Elements.Select(ToDto).ToList();
        return Page<PersonDetailsResponseDto>.Of(collectionDto, personPage.Total, personPage.Pageable);
    }

    public static PersonDetailsResponseDto ToDto(Person entity)
    {
        return new PersonDetailsResponseDto()
        {
            Id = entity.Id,
            Profile = new ProfileResponse()
            {
                Name = entity.Name,
                Gender = entity.Gender,
                BirthDate = entity.BirthDate,
                DaddyName = entity.DaddyName,
                MotherName = entity.MotherName,
            },
            Address = AddressMapper.ToDto(entity.Address),
            Scales = new List<ScaleDetailsResponseDto>(
                entity.PersonScales.Select(s => ScaleMapper.ToDto(s.Scale)).ToList()
            )
        };
    }
}
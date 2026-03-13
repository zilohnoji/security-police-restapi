using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.Util;

namespace SecurityPoliceMG.Api.Mapper;

public static class PersonMapper
{
    public static Person ToEntity(CreatePersonRequestDto requestDto)
    {
        return Person.PersonBuilder.Builder()
            .Name(requestDto.Profile.Name)
            .Gender(requestDto.Profile.Gender)
            .BirthDate(DateParser.ParseDateOnly(requestDto.Profile.BirthDate))
            .DaddyName(requestDto.Profile.DaddyName)
            .MotherName(requestDto.Profile.MotherName)
            .Photo(PhotoMapper.ToEntity(requestDto.Profile.Photo))
            .Build();
    }

    public static Page<PersonDetailsResponseDto> ToPageDto(Page<Person> personPage)
    {
        var collectionDto = personPage.Elements.Select(ToDto).ToList();
        return Page<PersonDetailsResponseDto>.Of(collectionDto, personPage.Total, personPage.Pageable);
    }

    public static PersonDetailsResponseDto ToDto(Person entity)
    {
        return PersonDetailsResponseDto.PersonDetailsBuilder.Builder()
            .Id(entity.Id)
            .Name(entity.Name)
            .Gender(entity.Gender)
            .BirthDate(entity.BirthDate)
            .DaddyName(entity.DaddyName)
            .MotherName(entity.MotherName)
            .Photo(PhotoMapper.ToDto(entity.Photo))
            .Address(AddressMapper.ToDto(entity.Address))
            .Scales(entity.PersonScales.Select(s => ScaleMapper.ToDto(s.Scale)).ToList())
            .Build();
    }
}
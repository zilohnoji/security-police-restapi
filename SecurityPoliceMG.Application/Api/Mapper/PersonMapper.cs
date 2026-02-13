using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Api.Mapper;

public static class PersonMapper
{
    public static Person ToEntity(CreatePersonRequestDto requestDto, User entity)
    {
        return Person.PersonBuilder.Builder()
            .Name(requestDto.Profile.Name)
            .Gender(requestDto.Profile.Gender)
            .BirthDate(PaseDate(requestDto.Profile.BirthDate))
            .DaddyName(requestDto.Profile.DaddyName)
            .MotherName(requestDto.Profile.MotherName)
            .Address(AddressMapper.ToEntity(requestDto.Address))
            .User(entity)
            .Photo(PhotoMapper.ToEntity(requestDto.Profile.Photo))
            .Build();
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

    private static DateOnly PaseDate(string date)
    {
        if (!TryParse(date, out DateOnly parsedDate))
        {
            throw new ArgumentException("Data de nascimento inválida!");
        }

        return DateOnly.Parse(parsedDate.ToString("MM/dd/yyyy"));
    }

    private static bool TryParse(string date, out DateOnly output)
    {
        if (string.IsNullOrEmpty(date))
        {
            output = new DateOnly();
            return false;
        }

        DateOnly.TryParse(date, out output);
        return true;
    }
}
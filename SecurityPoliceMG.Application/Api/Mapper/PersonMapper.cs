using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Api.Mapper;

public static class PersonMapper
{
    public static Person ToEntity(CreatePersonRequestDto requestDto)
    {
        return Person.PersonBuilder.Builder()
            .Name(requestDto.Name)
            .Gender(requestDto.Gender)
            .BirthDate(PaseDateTime(requestDto.BirthDate))
            .DaddyName(requestDto.DaddyName)
            .MotherName(requestDto.MotherName)
            .Address(AddressMapper.ToEntity(requestDto.Address))
            .Build();
    }

    public static PersonDetailsResponseDto ToDto(Person entity, Address address, Photo photo)
    {
        return PersonDetailsResponseDto.PersonDetailsBuilder.Builder()
            .Id(entity.Id)
            .Name(entity.Name)
            .Gender(entity.Gender)
            .BirthDate(entity.BirthDate)
            .DaddyName(entity.DaddyName)
            .MotherName(entity.MotherName)
            .Photo(PhotoMapper.ToDto(photo))
            .Address(AddressMapper.ToDto(address))
            .Build();
    }

    private static DateTime PaseDateTime(string date)
    {
        if (!TryParse(date, out DateTime parsedDate))
        {
            throw new ArgumentException("Data de nascimento inválida!");
        }

        return DateTime.Parse(parsedDate.ToString("MM/dd/yyyy"));
    }

    private static bool TryParse(string date, out DateTime output)
    {
        if (string.IsNullOrEmpty(date))
        {
            output = DateTime.Now;
            return false;
        }

        DateTime.TryParse(date, out output);
        return true;
    }
}
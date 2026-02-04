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
            .BirthDate(PaseDateTime(requestDto.Profile.BirthDate))
            .DaddyName(requestDto.Profile.DaddyName)
            .MotherName(requestDto.Profile.MotherName)
            .Address(AddressMapper.ToEntity(requestDto.Address))
            .User(entity)
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
            .User(new UserDetailsResponseDto(entity.User.Email, entity.User.Password))
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
using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Api.Mapper;

public static class ScaleMapper
{
    public static Scale ToEntity(CreateScaleRequestDto requestDto, Person personEntity)
    {
        return Scale.ScaleBuilder.Builder()
            .Description(requestDto.Description)
            .CreatedAt(ParseDateTime(DateTime.Now.ToString()))
            .IsCompleted(false)
            .StartsAt(ParseDateTime(requestDto.StartsAt))
            .FinishedAt(ParseDateTime(requestDto.FinishedAt))
            .Build();
    }

    public static ScaleDetailsResponseDto ToDto(Scale entity)
    {
        return ScaleDetailsResponseDto.ScaleBuilder.Builder()
            .ScaleId(entity.Id)
            .IsCompleted(entity.IsCompleted)
            .Description(entity.Description)
            .CreatedAt(entity.CreatedAt)
            .StartsAt(entity.StartsAt)
            .FinishedAt(entity.FinishedAt)
            .Build();
    }

    private static DateTime ParseDateTime(string date)
    {
        if (!TryParse(date, out DateTime parsedDate))
        {
            throw new ArgumentException("Data de nascimento inválida!");
        }

        return DateTime.SpecifyKind(parsedDate, DateTimeKind.Unspecified);
    }

    private static bool TryParse(string date, out DateTime output)
    {
        if (string.IsNullOrEmpty(date))
        {
            output = new DateTime();
            return false;
        }

        DateTime.TryParse(date, out output);
        return true;
    }
}
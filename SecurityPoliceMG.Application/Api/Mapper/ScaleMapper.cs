using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.Domain.Entity.Enum;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository.Base;

namespace SecurityPoliceMG.Api.Mapper;

public static class ScaleMapper
{
    public static Scale ToEntity(CreateScaleRequestDto requestDto)
    {
        return Scale.ScaleBuilder.Builder()
            .Description(requestDto.Description)
            .CreatedAt(ParseDateTime(DateTime.Now.ToString()))
            .IsCompleted(false)
            .StartsAt(ParseDateTime(requestDto.StartsAt))
            .FinishedAt(ParseDateTime(requestDto.FinishedAt))
            .Status(ScaleStatus.Created)
            .Build();
    }

    public static Page<ScaleDetailsResponseDto> ToPageDto(Page<Scale> scalePage)
    {
        var collectionDto = scalePage.Elements.Select(ToDto).ToList();
        return Page<ScaleDetailsResponseDto>.Of(collectionDto, scalePage.Total, scalePage.Pageable);
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

    public static DateTime ParseDateTime(string date)
    {
        if (!TryParse(date, out DateTime parsedDate))
        {
            throw new ArgumentException("Data inválida!");
        }

        return DateTime.SpecifyKind(parsedDate, DateTimeKind.Utc);
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
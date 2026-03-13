using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.Domain.Entity.Enum;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.Util;

namespace SecurityPoliceMG.Api.Mapper;

public static class ScaleMapper
{
    public static Scale ToEntity(CreateScaleRequestDto requestDto)
    {
        return Scale.ScaleBuilder.Builder()
            .Description(requestDto.Description)
            .CreatedAt(DateParser.ParseDateTime(DateTime.Now.ToString()))
            .IsCompleted(false)
            .StartsAt(DateParser.ParseDateTime(requestDto.StartsAt))
            .FinishedAt(DateParser.ParseDateTime(requestDto.FinishedAt))
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
}
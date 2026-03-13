using SecurityPoliceMG.Api.Dto.Scale.Response;

namespace SecurityPoliceMG.Api.Dto.Builder.FluentBuilder.Response;

public interface IScaleDetailsResponseDtoBuilder : IBuilder<ScaleDetailsResponseDto>
{
    static abstract IScaleDetailsResponseDtoBuilder Builder();

    IScaleDetailsResponseDtoBuilder ScaleId(Guid scaleId);

    IScaleDetailsResponseDtoBuilder IsCompleted(bool isCompleted);

    IScaleDetailsResponseDtoBuilder CreatedAt(DateTime createdAt);

    IScaleDetailsResponseDtoBuilder StartsAt(DateTime startsAt);

    IScaleDetailsResponseDtoBuilder FinishedAt(DateTime finishedAt);

    IScaleDetailsResponseDtoBuilder Description(String description);
}
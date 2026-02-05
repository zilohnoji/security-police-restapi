using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.Application.Builder;

namespace SecurityPoliceMG.Application.Api.Dto.Builder.Dto.Response;

public interface IScaleDetailsResponseDtoFluentBuilder : IBuilder<ScaleDetailsResponseDto>
{
    static abstract IScaleDetailsResponseDtoFluentBuilder Builder();

    IScaleDetailsResponseDtoFluentBuilder ScaleId(Guid scaleId);

    IScaleDetailsResponseDtoFluentBuilder IsCompleted(bool isCompleted);

    IScaleDetailsResponseDtoFluentBuilder CreatedAt(DateTime createdAt);

    IScaleDetailsResponseDtoFluentBuilder StartsAt(DateTime startsAt);

    IScaleDetailsResponseDtoFluentBuilder FinishedAt(DateTime finishedAt);

    IScaleDetailsResponseDtoFluentBuilder Description(String description);
}
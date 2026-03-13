using SecurityPoliceMG.Api.Dto.Address.Response;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Api.Dto.Photo.Response;
using SecurityPoliceMG.Api.Dto.Scale.Response;

namespace SecurityPoliceMG.Api.Dto.Builder.FluentBuilder.Response;

public interface IPersonDetailsResponseDtoBuilder : IBuilder<PersonDetailsResponseDto>
{
    static abstract IPersonDetailsResponseDtoBuilder Builder();

    IPersonDetailsResponseDtoBuilder Id(Guid id);

    IPersonDetailsResponseDtoBuilder Name(string name);

    IPersonDetailsResponseDtoBuilder BirthDate(DateOnly birthDate);

    IPersonDetailsResponseDtoBuilder Gender(string gender);

    IPersonDetailsResponseDtoBuilder MotherName(string motherName);

    IPersonDetailsResponseDtoBuilder DaddyName(string daddyName);

    IPersonDetailsResponseDtoBuilder Photo(PhotoDetailsResponseDto photo);

    IPersonDetailsResponseDtoBuilder Address(AddressDetailsResponseDto address);

    IPersonDetailsResponseDtoBuilder Scales(List<ScaleDetailsResponseDto> scale);
}
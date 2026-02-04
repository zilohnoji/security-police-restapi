using SecurityPoliceMG.Api.Dto.Person.Response;

namespace SecurityPoliceMG.Application.Builder.Dto.Response;

public interface IPersonDetailsResponseDtoFluentBuilder : IBuilder<PersonDetailsResponseDto>
{
    static abstract IPersonDetailsResponseDtoFluentBuilder Builder();

    IPersonDetailsResponseDtoFluentBuilder Id(Guid id);

    IPersonDetailsResponseDtoFluentBuilder Name(string name);

    IPersonDetailsResponseDtoFluentBuilder BirthDate(DateTime birthDate);

    IPersonDetailsResponseDtoFluentBuilder Gender(string gender);

    IPersonDetailsResponseDtoFluentBuilder MotherName(string motherName);

    IPersonDetailsResponseDtoFluentBuilder DaddyName(string daddyName);

    IPersonDetailsResponseDtoFluentBuilder Photo(PhotoDetailsResponseDto photo);

    IPersonDetailsResponseDtoFluentBuilder Address(AddressDetailsResponseDto address);
    
    IPersonDetailsResponseDtoFluentBuilder User(UserDetailsResponseDto user);
}
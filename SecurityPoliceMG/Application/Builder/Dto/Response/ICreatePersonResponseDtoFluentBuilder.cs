using SecurityPoliceMG.Api.Dto.Person.Response;

namespace SecurityPoliceMG.Application.Builder.Dto.Response;

public interface ICreatePersonResponseDtoFluentBuilder : IBuilder<CreatePersonResponseDto>
{
    ICreatePersonResponseDtoFluentBuilder Id(Guid id);

    ICreatePersonResponseDtoFluentBuilder Name(string name);

    ICreatePersonResponseDtoFluentBuilder BirthDate(DateTime birthDate);

    ICreatePersonResponseDtoFluentBuilder Gender(string gender);

    ICreatePersonResponseDtoFluentBuilder MotherName(string motherName);

    ICreatePersonResponseDtoFluentBuilder DaddyName(string daddyName);
}
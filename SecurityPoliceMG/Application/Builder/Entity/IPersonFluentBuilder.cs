using SecurityPoliceMG.Domain.Entity;

namespace SecurityPoliceMG.Application.Builder.Entity;

public interface IPersonFluentBuilder : IBuilder<Person>
{
    IPersonFluentBuilder Name(string name);

    IPersonFluentBuilder BirthDate(DateTime birthDate);

    IPersonFluentBuilder Gender(string gender);

    IPersonFluentBuilder MotherName(string motherName);

    IPersonFluentBuilder DaddyName(string daddyName);
}
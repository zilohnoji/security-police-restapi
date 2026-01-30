using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Application.Builder.Entity;

public interface IPersonFluentBuilder : IBuilder<Person>
{

    static abstract IPersonFluentBuilder Builder();
    IPersonFluentBuilder Name(string name);

    IPersonFluentBuilder BirthDate(DateTime birthDate);

    IPersonFluentBuilder Gender(string gender);

    IPersonFluentBuilder MotherName(string motherName);

    IPersonFluentBuilder DaddyName(string daddyName);
}
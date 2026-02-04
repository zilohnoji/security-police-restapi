using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Domain.Entity.Builder.FluentBuilder;

public interface IPersonBuilder : IBuilder<Person>
{
    static abstract IPersonBuilder Builder();

    IPersonBuilder Name(string name);

    IPersonBuilder BirthDate(DateTime birthDate);

    IPersonBuilder Gender(string gender);

    IPersonBuilder MotherName(string motherName);

    IPersonBuilder DaddyName(string daddyName);

    IPersonBuilder Address(Address address);
    
    IPersonBuilder User(User user);
}
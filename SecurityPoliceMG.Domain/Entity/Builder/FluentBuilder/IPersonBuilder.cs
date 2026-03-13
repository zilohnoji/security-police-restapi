using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Domain.Entity.Builder.FluentBuilder;

public interface IPersonBuilder : IBuilder<Person>
{
    static abstract IPersonBuilder Builder();

    IPersonBuilder Name(string name);

    IPersonBuilder BirthDate(DateOnly birthDate);

    IPersonBuilder Gender(string gender);

    IPersonBuilder MotherName(string motherName);

    IPersonBuilder DaddyName(string daddyName);

    IPersonBuilder AddressId(Guid addressId);

    IPersonBuilder UserId(Guid userId);

    IPersonBuilder Photo(Photo photo);
}
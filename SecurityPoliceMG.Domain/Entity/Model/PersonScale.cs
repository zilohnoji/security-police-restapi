namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class PersonScale : BaseEntity
{
    public Guid ScaleId { get; private set; }

    public Scale Scale { get; private set; }

    public Guid PersonId { get; private set; }

    public Person Person { get; private set; }

    public int HoursWorked { get; private set; }

    private PersonScale()
    {
    }

    private PersonScale(Scale scale, Person person, int hoursWorked)
    {
        HoursWorked = hoursWorked;
        Scale = scale;
        Person = person;
    }

    public static PersonScale Of(Scale scale, Person person, int hoursWorked)
    {
        return new PersonScale(scale, person, hoursWorked);
    }
}
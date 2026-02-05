namespace SecurityPoliceMG.Domain.Entity.Model;

public class PersonScale : BaseEntity
{
    public Guid ScaleId { get; private set; } = Guid.Empty;

    public Scale Scale { get; private set; } = Scale.Empty;
    
    public Guid PersonId { get; private set; } = Guid.Empty;
    
    public Person Person { get; private set; } = Person.Empty;

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
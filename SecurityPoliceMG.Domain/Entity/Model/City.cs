namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class City : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    public string Uf { get; private set; } = string.Empty;

    public static readonly City Empty = new City();

    private City()
    {
    }

    private City(string name, string uf)
    {
        Name = name;
        Uf = uf;
    }

    public static City Of(string name, string uf)
    {
        return new City(name, uf);
    }
}
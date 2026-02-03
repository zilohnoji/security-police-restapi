namespace SecurityPoliceMG.Domain.Entity.Builder;

public interface IBuilder<out T>
{
    T Build();
}
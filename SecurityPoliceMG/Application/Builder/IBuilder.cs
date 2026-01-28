namespace SecurityPoliceMG.Application.Builder;

public interface IBuilder<out T>
{
    T Build();
}
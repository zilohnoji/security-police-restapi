namespace SecurityPoliceMG.Application.Builder;

public interface IBuilder<out TResult>
{
    TResult Build();
}
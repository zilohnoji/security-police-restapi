namespace SecurityPoliceMG.Api.Dto.Builder;

public interface IBuilder<out TResult>
{
    TResult Build();
}
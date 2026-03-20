using SecurityPoliceMG.Domain.Entity.Enum;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Domain.Entity.Builder.FluentBuilder;

public interface IScaleBuilder : IBuilder<Scale>
{
    static abstract IScaleBuilder Builder(Scale? entity);

    IScaleBuilder IsCompleted(bool isCompleted);

    IScaleBuilder CreatedAt(DateTime createdAt);

    IScaleBuilder StartsAt(DateTime startsAt);

    IScaleBuilder FinishedAt(DateTime finishedAt);

    IScaleBuilder Description(string description);
    
    IScaleBuilder Status(ScaleStatus status);
}
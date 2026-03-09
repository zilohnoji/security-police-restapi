namespace SecurityPoliceMG.Domain.Entity.Enum;

using System;

public enum ScaleStatus
{
    Started,
    InProgress,
    Completed
}

public static class ScaleStatusMethods
{
    public static ScaleStatus Parse(string scaleStatus)
    {
        var canParse = Enum.TryParse(scaleStatus, out ScaleStatus response);

        return !canParse
            ? throw new ArgumentException("ScaleStatus inválido!!")
            : response;
    }
}
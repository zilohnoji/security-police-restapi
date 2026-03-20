namespace SecurityPoliceMG.Service.Validator.ScaleValidator.AddOnScaleValidation.Validation;

public sealed class ScaleAddOnScaleConflictValidation : IScaleAddOnScaleValidator
{
    public void Validate(ScaleAddOnScaleArgs addOnScaleArgs)
    {
        var startDate = addOnScaleArgs.scaleEntity.StartsAt;
        var finishDate = addOnScaleArgs.scaleEntity.FinishedAt;

        var scalePeriod = addOnScaleArgs.personEntity.PersonScales.FirstOrDefault(s =>
            (s.Scale.StartsAt <= startDate &&
             s.Scale.FinishedAt >= finishDate) ||
            (s.Scale.StartsAt >= startDate &&
             s.Scale.FinishedAt <= finishDate)
        );

        if (scalePeriod is not null)
        {
            throw new ArgumentException($"Já existe uma escala nesse período para o usuário de ID {addOnScaleArgs.personEntity.Id}");
        }
    }
}
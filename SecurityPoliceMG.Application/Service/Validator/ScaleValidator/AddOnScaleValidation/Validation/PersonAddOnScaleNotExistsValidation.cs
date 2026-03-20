namespace SecurityPoliceMG.Service.Validator.ScaleValidator.AddOnScaleValidation.Validation;

public sealed class PersonAddOnScaleNotExistsValidation : IScaleAddOnScaleValidator
{
    public void Validate(ScaleAddOnScaleArgs addOnScaleArgs)
    {
        if (addOnScaleArgs.personEntity is null)
        {
            throw new ArgumentException($"Essa pessoa não existe");
        }
    }
}
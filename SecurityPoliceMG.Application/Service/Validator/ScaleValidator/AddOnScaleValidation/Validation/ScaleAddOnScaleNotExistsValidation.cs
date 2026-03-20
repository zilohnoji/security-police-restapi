using SecurityPoliceMG.EFCore.Repository.Impl;

namespace SecurityPoliceMG.Service.Validator.ScaleValidator.AddOnScaleValidation.Validation;

public sealed class ScaleAddOnScaleNotExistsValidation : IScaleAddOnScaleValidator
{
    private readonly ScaleRepositoryImpl _scaleRepositoryImpl;

    public ScaleAddOnScaleNotExistsValidation(ScaleRepositoryImpl scaleRepositoryImpl)
    {
        _scaleRepositoryImpl = scaleRepositoryImpl;
    }

    public void Validate(ScaleAddOnScaleArgs addOnScaleArgs)
    {
        var scaleEntity = _scaleRepositoryImpl.FindById(addOnScaleArgs.scaleEntity.Id);

        if (scaleEntity is null)
        {
            throw new ArgumentException($"Essa escala não existe");
        }
    }
}
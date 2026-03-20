using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Service.Validator.ScaleValidator.AddOnScaleValidation;

public record ScaleAddOnScaleArgs(Scale scaleEntity, Person personEntity)
{
}
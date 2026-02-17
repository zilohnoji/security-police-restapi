using FluentValidation;
using SecurityPoliceMG.Api.Dto.Address.Request;

namespace SecurityPoliceMG.Api.Dto.Address.Validator;

public sealed class CreateAddressValidator : AbstractValidator<CreateAddressRequestDto>
{
    public CreateAddressValidator()
    {
        RuleFor(address => address.PatioType)
            .NotEmpty().WithMessage(ErrorMessages.StreetTypeIsEmpty)
            .Length(1, 50).WithMessage(ErrorMessages.StreetTypeMaxCharacters);

        RuleFor(address => address.Street)
            .NotEmpty().WithMessage(ErrorMessages.StreetIsEmpty)
            .Length(1, 200).WithMessage(ErrorMessages.StreetMaxCharacters);

        RuleFor(address => address.Number)
            .NotEmpty().WithMessage(ErrorMessages.NumberIsRequired);

        RuleFor(address => address.Neighborhood)
            .NotEmpty().WithMessage(ErrorMessages.NeighborhoodIsEmpty)
            .Length(1, 100).WithMessage(ErrorMessages.NeighborhoodMaxCharacters);

        RuleFor(address => address.City)
            .NotNull().WithMessage(ErrorMessages.CityIsRequired);
    }

    private static class ErrorMessages
    {
        public const string StreetTypeIsEmpty = "The street_type is required";
        public const string StreetTypeMaxCharacters = "The street_type should be 1 and 50 characters";

        public const string StreetIsEmpty = "The street is required";
        public const string StreetMaxCharacters = "The street should be 1 and 200 characters";

        public const string NumberIsRequired = "The number is required";

        public const string NeighborhoodIsEmpty = "The neighborhood is required";
        public const string NeighborhoodMaxCharacters = "The neighborhood should be 1 and 100 characters";

        public const string CityIsRequired = "The city is required";
    }
}
namespace LogisticsCorp.Web.Validators;

public class ClientViewModelValidator : AbstractValidator<ClientViewModel>
{
    public ClientViewModelValidator()
    {
        RuleFor(x => x.User.FullName)
            .NotEmpty().WithMessage("Full name is required")
            .MaximumLength(ValidationConstants.TEXT_FIELD_MAX_LENGTH)
            .WithMessage($"Full name cannot exceed {ValidationConstants.TEXT_FIELD_MAX_LENGTH} characters");

        RuleFor(x => x.User.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage(ValidationConstants.EMAIL);

        RuleFor(x => x.User.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required")
            .Matches(Constants.PHONE_FORMAT_REGEX).WithMessage(ValidationConstants.PHONE_NUMBER);

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required")
            .MaximumLength(ValidationConstants.TEXT_FIELD_LARGE_MAX_LENGTH)
            .WithMessage($"Address cannot exceed {ValidationConstants.TEXT_FIELD_LARGE_MAX_LENGTH} characters");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required")
            .MaximumLength(ValidationConstants.TEXT_FIELD_MAX_LENGTH)
            .WithMessage($"City cannot exceed {ValidationConstants.TEXT_FIELD_MAX_LENGTH} characters");

        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("Postal Code is required")
            .MaximumLength(10)
            .WithMessage("Postal code cannot exceed 10 characters");
    }
}

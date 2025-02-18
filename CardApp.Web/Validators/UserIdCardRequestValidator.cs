using FluentValidation;

namespace CardApp.Web.Validators
{
    public class UserIdCardRequestValidator : AbstractValidator<(string UserId, string CardNumber)>
    {
        public UserIdCardRequestValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId cannot be empty")
                .Length(1, 20).WithMessage("Length of UserId must be between 1 and 20 characters")
                .Must(x => x.StartsWith("U")).WithMessage("UserId must start with 'U'");

            RuleFor(x => x.CardNumber)
                .NotEmpty().WithMessage("Card Number cannot be empty")
                .Length(1, 20).WithMessage("Length of Card Number must be between 1 and 20 characters")
                .Must(x => x.StartsWith("C")).WithMessage("Card Number must start with 'C'");
        }
    }
}

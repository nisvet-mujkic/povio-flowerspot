using FluentValidation;
using Povio.FlowerSpot.Application.Features.Users.Commands.Register;

namespace Povio.FlowerSpot.Application.Features.Users.Validators.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .Length(6, 20)
                .Must(x => !x.Contains(':'))
                .WithMessage("Username can't contain ':' characters.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(6, 100)
                .Must(password => !password.Contains(':'))
                .WithMessage("Password can't contain ':' characters.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}

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
                .Must(x => !x.Contains(':'));

            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(6, 100)
                .Must((command, password) => !password.Contains(':') && password != command.Username);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}

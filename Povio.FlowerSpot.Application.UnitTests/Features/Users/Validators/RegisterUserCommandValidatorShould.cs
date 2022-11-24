using FluentValidation.TestHelper;
using Povio.FlowerSpot.Application.Features.Users.Commands.Register;
using Povio.FlowerSpot.Application.Features.Users.Validators.Register;
using Xunit;

namespace Povio.FlowerSpot.Application.UnitTests.Features.Users.Validators
{
    public class RegisterUserCommandValidatorShould
    {
        private readonly RegisterUserCommandValidator _validator = new();

        [Theory]
        [InlineData("test", "emailaddress.com", "test")]
        [InlineData("test:test", "emailaddress.com", "test:test")]
        public void HaveErrorsIfInputDataIsInvalid(string username, string email, string password)
        {
            var validationResult = _validator.TestValidate(new RegisterUserCommand(username, password, email));

            validationResult.ShouldHaveValidationErrorFor(x => x.Username);
            validationResult.ShouldHaveValidationErrorFor(x => x.Email);
            validationResult.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Theory]
        [InlineData("nisvetmujkic", "nisvetmujkic")]
        public void HaveErrorsIfUsernameAndPasswordAreEqual(string username, string password)
        {
            var validationResult = _validator.TestValidate(new RegisterUserCommand(username, password, "email@address.com"));

            validationResult.ShouldNotHaveValidationErrorFor(x => x.Username);
            validationResult.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Theory]
        [InlineData("nisvetmujkic", "nisvet.mujkic@gmail.com", "nisvet2022")]
        public void NotHaveErrorsInputDataIsValid(string username, string email, string password)
        {
            var validationResult = _validator.TestValidate(new RegisterUserCommand(username, password, email));

            validationResult.ShouldNotHaveValidationErrorFor(x => x.Username);
            validationResult.ShouldNotHaveValidationErrorFor(x => x.Email);
            validationResult.ShouldNotHaveValidationErrorFor(x => x.Password);
        }
    }
}

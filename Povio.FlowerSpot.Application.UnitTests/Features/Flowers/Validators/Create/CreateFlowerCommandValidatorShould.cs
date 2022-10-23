using FluentValidation.TestHelper;
using Povio.FlowerSpot.Application.Features.Flowers.Commands.Create;
using Povio.FlowerSpot.Application.Features.Flowers.Validators.Create;
using Xunit;

namespace Povio.FlowerSpot.Application.UnitTests.Features.Flowers.Validators.Create
{
    public class CreateFlowerCommandValidatorShould
    {
        private readonly CreateFlowerCommandValidator _validator = new();

        [Fact]
        public void HaveValidationErrorForNameAndImageRefIfInputIsInvalid()
        {
            var validationResult = _validator.TestValidate(new CreateFlowerCommand("", "", "description"));

            validationResult.ShouldHaveValidationErrorFor(x => x.Name);
            validationResult.ShouldHaveValidationErrorFor(x => x.ImageRef);
        }

        [Fact]
        public void NotHaveValidationErrorForNameAndImageRefIfInputIsValid()
        {
            var validationResult = _validator.TestValidate(new CreateFlowerCommand("name", "image-ref", "description"));

            validationResult.ShouldNotHaveAnyValidationErrors();
        }
    }
}

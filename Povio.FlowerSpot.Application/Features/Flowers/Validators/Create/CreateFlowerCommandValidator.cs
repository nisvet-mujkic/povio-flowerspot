using FluentValidation;
using Povio.FlowerSpot.Application.Features.Flowers.Commands.Create;

namespace Povio.FlowerSpot.Application.Features.Flowers.Validators.Create
{
    public class CreateFlowerCommandValidator : AbstractValidator<CreateFlowerCommand>
    {
        public CreateFlowerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 150);

            RuleFor(x => x.ImageRef)
                .NotEmpty();
        }
    }
}
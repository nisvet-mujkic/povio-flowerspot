using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Application.Features.Flowers.Commands
{
    public record CreateFlowerCommand(string Name, string ImageRef, string Description) : IRequest;

    public class CreateFlowerCommandHandler : AsyncRequestHandler<CreateFlowerCommand>
    {
        private readonly IFlowerRepository _flowerRepository;

        public CreateFlowerCommandHandler(IFlowerRepository flowerRepository)
        {
            _flowerRepository = flowerRepository;
        }

        protected override async Task Handle(CreateFlowerCommand request, CancellationToken cancellationToken)
        {
            var flower = new Flower()
            {
                Name = request.Name,
                ImageRef = request.ImageRef,
                Description = request.Description
            };

            await _flowerRepository.AddAsync(flower);
        }
    }
}

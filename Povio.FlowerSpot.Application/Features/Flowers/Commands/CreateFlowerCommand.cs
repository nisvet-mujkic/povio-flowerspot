using AutoMapper;
using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Application.Features.Flowers.Commands
{
    public record CreateFlowerCommand(string Name, string ImageRef, string Description) : IRequest;

    public class CreateFlowerCommandHandler : IRequestHandler<CreateFlowerCommand>
    {
        private readonly IMapper _mapper;
        private readonly IFlowerRepository _flowerRepository;

        public CreateFlowerCommandHandler(IMapper mapper, IFlowerRepository flowerRepository)
        {
            _mapper = mapper;
            _flowerRepository = flowerRepository;
        }

        public async Task<Unit> Handle(CreateFlowerCommand request, CancellationToken cancellationToken)
        {
            var flower = _mapper.Map<Flower>(request);
            await _flowerRepository.AddAsync(flower, cancellationToken);

            return Unit.Value;
        }
    }
}
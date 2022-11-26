using Ardalis.Result;
using AutoMapper;
using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Contracts.Responses.Flowers;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Application.Features.Flowers.Commands.Create
{
    public record CreateFlowerCommand(string Name, string ImageRef, string Description) : IRequest<Result<CreateFlowerResponse>>;

    public class CreateFlowerCommandHandler : IRequestHandler<CreateFlowerCommand, Result<CreateFlowerResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IFlowerRepository _flowerRepository;

        public CreateFlowerCommandHandler(IMapper mapper, IFlowerRepository flowerRepository)
        {
            _mapper = mapper;
            _flowerRepository = flowerRepository;
        }

        public async Task<Result<CreateFlowerResponse>> Handle(CreateFlowerCommand request, CancellationToken cancellationToken)
        {
            var flower = _mapper.Map<Flower>(request);
            try
            {
                var entity = await _flowerRepository.AddAsync(flower, cancellationToken);
                return _mapper.Map<CreateFlowerResponse>(entity);

            }
            catch (Exception e)
            {

                throw;
            }
            return _mapper.Map<CreateFlowerResponse>(null);
        }
    }
}
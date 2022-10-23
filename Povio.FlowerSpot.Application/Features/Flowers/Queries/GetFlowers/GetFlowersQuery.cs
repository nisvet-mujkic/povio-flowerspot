using AutoMapper;
using MediatR;
using OneOf;
using OneOf.Types;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Contracts.Responses.Flowers;

namespace Povio.FlowerSpot.Application.Features.Flowers.Queries.GetFlowers
{
    public record GetFlowersQuery : IRequest<OneOf<GetFlowersResponse, None>>;

    public class GetFlowersQueryHandler : IRequestHandler<GetFlowersQuery, OneOf<GetFlowersResponse, None>>
    {
        private readonly IMapper _mapper;
        private readonly IFlowerRepository _flowerRepository;

        public GetFlowersQueryHandler(IMapper mapper, IFlowerRepository flowerRepository)
        {
            _mapper = mapper;
            _flowerRepository = flowerRepository;
        }

        public async Task<OneOf<GetFlowersResponse, None>> Handle(GetFlowersQuery request, CancellationToken cancellationToken)
        {
            var flowers = await _flowerRepository.GetAllAsync(cancellationToken);

            if (flowers.Count == 0)
                return new None();

            var mapped = _mapper.Map<List<FlowerDto>>(flowers);

            return new GetFlowersResponse()
            {
                Flowers = mapped
            };
        }
    }
}
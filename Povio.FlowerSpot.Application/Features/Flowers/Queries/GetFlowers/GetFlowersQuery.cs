using Ardalis.Result;
using AutoMapper;
using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Contracts.Responses.Flowers;

namespace Povio.FlowerSpot.Application.Features.Flowers.Queries.GetFlowers
{
    public record GetFlowersQuery : IRequest<Result<GetFlowersResponse>>;

    public class GetFlowersQueryHandler : IRequestHandler<GetFlowersQuery, Result<GetFlowersResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IFlowerRepository _flowerRepository;

        public GetFlowersQueryHandler(IMapper mapper, IFlowerRepository flowerRepository)
        {
            _mapper = mapper;
            _flowerRepository = flowerRepository;
        }

        public async Task<Result<GetFlowersResponse>> Handle(GetFlowersQuery request, CancellationToken cancellationToken)
        {
            var flowers = await _flowerRepository.GetAllAsync(cancellationToken);

            var mapped = _mapper.Map<List<FlowerDto>>(flowers);

            return new GetFlowersResponse()
            {
                Flowers = mapped
            };
        }
    }
}
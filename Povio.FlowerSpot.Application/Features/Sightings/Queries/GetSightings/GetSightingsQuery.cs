using AutoMapper;
using MediatR;
using OneOf;
using OneOf.Types;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Contracts.Responses.Sightings;

namespace Povio.FlowerSpot.Application.Features.Sightings.Queries.GetSightings
{
    public record GetSightingsQuery : IRequest<OneOf<GetSightingsResponse, None>>;

    public class GetSightingsQueryHandler : IRequestHandler<GetSightingsQuery, OneOf<GetSightingsResponse, None>>
    {
        private readonly IMapper _mapper;
        private readonly ISightingRepository _sightingRepository;

        public GetSightingsQueryHandler(IMapper mapper, ISightingRepository sightingRepository)
        {
            _mapper = mapper;
            _sightingRepository = sightingRepository;
        }

        public async Task<OneOf<GetSightingsResponse, None>> Handle(GetSightingsQuery request, CancellationToken cancellationToken)
        {
            var sightings = await _sightingRepository.GetAllAsync(cancellationToken);

            if (sightings.Count == 0)
                return new None();

            var mapped = _mapper.Map<List<SightingDto>>(sightings);

            return new GetSightingsResponse()
            {
                Sightings = mapped
            };
        }
    }
}
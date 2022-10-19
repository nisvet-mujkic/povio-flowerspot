﻿using AutoMapper;
using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Contracts.Responses.Sightings;

namespace Povio.FlowerSpot.Application.Features.Sightings.Queries.GetSightings
{
    public record GetSightingsQuery : IRequest<GetSightingsResponse>;

    public class GetSightingsQueryHandler : IRequestHandler<GetSightingsQuery, GetSightingsResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISightingRepository _sightingRepository;

        public GetSightingsQueryHandler(IMapper mapper, ISightingRepository sightingRepository)
        {
            _mapper = mapper;
            _sightingRepository = sightingRepository;
        }

        public async Task<GetSightingsResponse> Handle(GetSightingsQuery request, CancellationToken cancellationToken)
        {
            var sightings = await _sightingRepository.GetAllAsync(cancellationToken);
            var mapped = _mapper.Map<List<SightingDto>>(sightings);

            return new GetSightingsResponse()
            {
                Sightings = mapped
            };
        }
    }
}
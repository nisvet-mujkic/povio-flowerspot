using AutoMapper;
using MediatR;
using Povio.FlowerSpot.Application.Contracts.Clients;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Contracts.Responses.Sightings;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Application.Features.Sightings.Commands.Create
{
    public record CreateCommand(decimal Longitude, decimal Latitude, int UserId, int FlowerId, string ImageRef) : IRequest<CreateSightingResponse>;

    public class CreateCommandHandler : IRequestHandler<CreateCommand, CreateSightingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISightingRepository _sightingRepository;
        private readonly IQuoteClient _quoteClient;

        public CreateCommandHandler(IMapper mapper, ISightingRepository sightingRepository, IQuoteClient quoteClient)
        {
            _mapper = mapper;
            _sightingRepository = sightingRepository;
            _quoteClient = quoteClient;
        }

        public async Task<CreateSightingResponse> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var sighting = _mapper.Map<Sighting>(request);

            var entity = await _sightingRepository.AddAsync(sighting, cancellationToken);
            var quote = await _quoteClient.GetQuoteOfTheDayAsync();

            return _mapper.Map<CreateSightingResponse>(entity);
        }
    }
}

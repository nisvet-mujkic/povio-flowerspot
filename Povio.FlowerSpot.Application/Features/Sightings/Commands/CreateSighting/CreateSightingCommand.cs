using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Contracts.Responses.Sightings;

namespace Povio.FlowerSpot.Application.Features.Sightings.Commands.CreateSighting
{
    public record CreateSightingCommand(decimal Longitude, decimal Latitude, int UserId, int FlowerId, string ImageRef) : IRequest<CreateSightingResponse>;

    public class CreateSightingCommandHandler : IRequestHandler<CreateSightingCommand, CreateSightingResponse>
    {
        private readonly ISightingRepository _sightingRepository;

        public CreateSightingCommandHandler(ISightingRepository sightingRepository)
        {
            _sightingRepository = sightingRepository;
        }

        public Task<CreateSightingResponse> Handle(CreateSightingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

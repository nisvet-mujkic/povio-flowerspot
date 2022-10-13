using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Contracts.Responses.Sightings;

namespace Povio.FlowerSpot.Application.Features.Sightings.Commands.CreateSighting
{
    public record CreateSightingCommand(decimal Longitude, decimal Latitude, int UserId, int FlowerId, string ImageRef) : IRequest<CreateSightingResponse>;

    public class CreateSightingCommandHandler : RequestHandler<CreateSightingCommand, CreateSightingResponse>
    {
        private readonly ISightingRepository _sightingRepository;

        public CreateSightingCommandHandler(ISightingRepository sightingRepository)
        {
            _sightingRepository = sightingRepository;
        }

        protected override CreateSightingResponse Handle(CreateSightingCommand request)
        {
            throw new NotImplementedException();
        }
    }
}

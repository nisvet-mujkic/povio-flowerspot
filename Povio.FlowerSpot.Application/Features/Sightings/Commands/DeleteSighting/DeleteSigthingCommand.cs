using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;

namespace Povio.FlowerSpot.Application.Features.Sightings.Commands.DeleteSighting
{
    public record DeleteSigthingCommand(int SightingId, int CurrentUserId) : IRequest;

    public class DeleteSigthingCommandHandler : IRequestHandler<DeleteSigthingCommand>
    {
        private readonly ISightingRepository _sightingRepository;

        public DeleteSigthingCommandHandler(ISightingRepository sightingRepository)
        {
            _sightingRepository = sightingRepository;
        }

        public async Task<Unit> Handle(DeleteSigthingCommand request, CancellationToken cancellationToken)
        {
            var sighting = await _sightingRepository.GetByIdAsync(request.SightingId, cancellationToken);
            
            if (sighting is not null && sighting.UserId != request.CurrentUserId)
                return Unit.Value;

            await _sightingRepository.DeleteAsync(sighting, cancellationToken);

            return Unit.Value;
        }
    }
}
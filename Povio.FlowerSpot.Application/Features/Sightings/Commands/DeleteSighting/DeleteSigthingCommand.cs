using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;

namespace Povio.FlowerSpot.Application.Features.Sightings.Commands.DeleteSighting
{
    public record DeleteSigthingCommand(int SightingId) : IRequest;

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

            // check current user id 
            if (sighting is not null && sighting.UserId != 1)
                return Unit.Value;

            await _sightingRepository.DeleteAsync(new Domain.Entities.Sighting() { SightingId = request.SightingId }, cancellationToken);

            return Unit.Value;
        }
    }
}`
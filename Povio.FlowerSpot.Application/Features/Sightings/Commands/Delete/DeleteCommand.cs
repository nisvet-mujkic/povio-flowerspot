using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;

namespace Povio.FlowerSpot.Application.Features.Sightings.Commands.Delete
{
    public record DeleteCommand(int SightingId, int CurrentUserId) : IRequest;

    public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
    {
        private readonly ISightingRepository _sightingRepository;

        public DeleteCommandHandler(ISightingRepository sightingRepository)
        {
            _sightingRepository = sightingRepository;
        }

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var sighting = await _sightingRepository.GetByIdAsync(request.SightingId, cancellationToken);
            
            if (sighting is not null && sighting.UserId != request.CurrentUserId)
                return Unit.Value;

            await _sightingRepository.DeleteAsync(sighting, cancellationToken);

            return Unit.Value;
        }
    }
}
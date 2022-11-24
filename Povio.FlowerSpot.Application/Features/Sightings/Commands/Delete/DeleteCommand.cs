using Ardalis.Result;
using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;

namespace Povio.FlowerSpot.Application.Features.Sightings.Commands.Delete
{
    public record DeleteCommand(int SightingId, int CurrentUserId) : IRequest<Result>;

    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, Result>
    {
        private readonly ISightingRepository _sightingRepository;

        public DeleteCommandHandler(ISightingRepository sightingRepository)
        {
            _sightingRepository = sightingRepository;
        }

        public async Task<Result> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var sighting = await _sightingRepository.GetByIdAsync(request.SightingId, cancellationToken);
            
            if (sighting is null || sighting.UserId != request.CurrentUserId)
                return Result.Error("Sighting not found");

            await _sightingRepository.DeleteAsync(sighting, cancellationToken);

            return Result.Success();
        }
    }
}
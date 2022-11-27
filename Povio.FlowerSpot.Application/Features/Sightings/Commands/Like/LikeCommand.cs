using Ardalis.Result;
using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;

namespace Povio.FlowerSpot.Application.Features.Sightings.Commands.Like
{
    public record LikeCommand(int SightingId, int CurrentUserId) : IRequest<Result>;

    public class LikeCommandHandler : IRequestHandler<LikeCommand, Result>
    {
        private readonly ISightingRepository _sightingRepository;
        private readonly ILikeRepository _likeRepository;

        public LikeCommandHandler(ISightingRepository sightingRepository, ILikeRepository likeRepository)
        {
            _sightingRepository = sightingRepository;
            _likeRepository = likeRepository;
        }

        public async Task<Result> Handle(LikeCommand request, CancellationToken cancellationToken)
        {
            var sighting = await _sightingRepository.GetByIdAsync(request.SightingId, cancellationToken);

            if (sighting is null)
                return Result.Error($"Sighting with id: '{request.SightingId}' doesn't exist");

            var like = await _likeRepository.GetByCompositeKeyAsync(request.SightingId, request.CurrentUserId, cancellationToken);

            if (like is not null)
                return Result.Error("This user had already liked this sighting");

            await _likeRepository.AddAsync(new Domain.Entities.Like()
            {
                SightingId = request.SightingId,
                UserId = request.CurrentUserId
            }, cancellationToken);

            return Result.Success();
        }
    }
}
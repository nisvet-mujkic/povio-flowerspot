using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;

namespace Povio.FlowerSpot.Application.Features.Sightings.Commands.Dislike
{
    public record DislikeCommand(int SightingId, int CurrentUserId) : IRequest;

    public class DislikeCommandHandler : IRequestHandler<DislikeCommand>
    {
        private readonly ILikeRepository _likeRepository;

        public DislikeCommandHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<Unit> Handle(DislikeCommand request, CancellationToken cancellationToken)
        {
            var like = await _likeRepository.FindByCompositeKeyAsync(request.SightingId, request.CurrentUserId, cancellationToken);

            if (like is null || like.UserId != request.CurrentUserId)
                return Unit.Value;

            await _likeRepository.DeleteAsync(like, cancellationToken);

            return Unit.Value;
        }
    }
}
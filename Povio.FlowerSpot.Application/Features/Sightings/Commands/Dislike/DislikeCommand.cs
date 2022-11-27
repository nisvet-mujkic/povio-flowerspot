using Ardalis.Result;
using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;

namespace Povio.FlowerSpot.Application.Features.Sightings.Commands.Dislike
{
    public record DislikeCommand(int SightingId, int CurrentUserId) : IRequest<Result>;

    public class DislikeCommandHandler : IRequestHandler<DislikeCommand, Result>
    {
        private readonly ILikeRepository _likeRepository;

        public DislikeCommandHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<Result> Handle(DislikeCommand request, CancellationToken cancellationToken)
        {
            var like = await _likeRepository.GetByCompositeKeyAsync(request.SightingId, request.CurrentUserId, cancellationToken);

            if (like is null)
                return Result.Error("Entity doesn't exist");

            if (like.UserId != request.CurrentUserId)
                return Result.Error("User can only remove likes he made");

            await _likeRepository.DeleteAsync(like, cancellationToken);

            return Result.Success();
        }
    }
}
using Ardalis.Result;
using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;

namespace Povio.FlowerSpot.Application.Features.Sightings.Commands.Like
{
    public record LikeCommand(int SightingId, int CurrentUserId) : IRequest<Result>;

    public class LikeCommandHandler : IRequestHandler<LikeCommand, Result>
    {
        private readonly ILikeRepository _likeRepository;

        public LikeCommandHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<Result> Handle(LikeCommand request, CancellationToken cancellationToken)
        {
            await _likeRepository.AddAsync(new Domain.Entities.Like()
            {
                SightingId = request.SightingId,
                UserId = request.CurrentUserId
            }, cancellationToken);

            return Result.Success();
        }
    }
}
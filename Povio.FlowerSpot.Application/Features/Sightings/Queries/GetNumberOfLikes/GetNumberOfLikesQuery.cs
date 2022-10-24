using Ardalis.Result;
using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Contracts.Responses.Sightings;

namespace Povio.FlowerSpot.Application.Features.Sightings.Queries.GetNumberOfLikes
{
    public record GetNumberOfLikesQuery(int SightingId) : IRequest<Result<GetNumberOfLikesResponse>>;

    public class GetNumberOfLikesQueryHandler : IRequestHandler<GetNumberOfLikesQuery, Result<GetNumberOfLikesResponse>>
    {
        private readonly ILikeRepository _likeRepository;

        public GetNumberOfLikesQueryHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<Result<GetNumberOfLikesResponse>> Handle(GetNumberOfLikesQuery request, CancellationToken cancellationToken)
        {
            var numberOfLikes = await _likeRepository.GetNumberOfLikesAsync(request.SightingId, cancellationToken);

            return new GetNumberOfLikesResponse()
            {
                NumberOfLikes = numberOfLikes
            };
        }
    }
}

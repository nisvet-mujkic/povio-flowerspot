using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Contracts.Responses.Sightings;

namespace Povio.FlowerSpot.Application.Features.Sightings.Queries.GetNumberOfLikes
{
    public record GetNumberOfLikesQuery(int SightingId) : IRequest<GetNumberOfLikesResponse>;

    public class GetNumberOfLikesQueryHandler : IRequestHandler<GetNumberOfLikesQuery, GetNumberOfLikesResponse>
    {
        private readonly ILikeRepository _likeRepository;

        public GetNumberOfLikesQueryHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<GetNumberOfLikesResponse> Handle(GetNumberOfLikesQuery request, CancellationToken cancellationToken)
        {
            var numberOfLikes = await _likeRepository.GetNumberOfLikesAsync(request.SightingId, cancellationToken);

            return new GetNumberOfLikesResponse()
            {
                NumberOfLikes = numberOfLikes
            };
        }
    }
}

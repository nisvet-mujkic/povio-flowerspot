using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Povio.FlowerSpot.Api.Controllers.Common;
using Povio.FlowerSpot.Application.Features.Sightings.Commands.Dislike;
using Povio.FlowerSpot.Application.Features.Sightings.Commands.Like;
using Povio.FlowerSpot.Application.Features.Sightings.Queries.GetNumberOfLikes;
using Povio.FlowerSpot.Contracts.Responses.Sightings;

namespace Povio.FlowerSpot.Api.Controllers
{
    [Route("api/sightings/{sightingId:int:min(1)}/likes")]
    public class LikeController : ApplicationController
    {
        public LikeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetNumberOfLikesResponse))]
        public async Task<Result<GetNumberOfLikesResponse>> Get(int sightingId)
            => await Mediator.Send(new GetNumberOfLikesQuery(sightingId), HttpContext.RequestAborted);

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Result> Post(int sightingId)
            => await Mediator.Send(new LikeCommand(sightingId, CurrentUserId), HttpContext.RequestAborted);

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<Result> Delete(int sightingId)
            => await Mediator.Send(new DislikeCommand(sightingId, CurrentUserId), HttpContext.RequestAborted);
    }
}
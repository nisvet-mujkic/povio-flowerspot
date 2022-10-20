using MediatR;
using Microsoft.AspNetCore.Mvc;
using Povio.FlowerSpot.Api.Controllers.Common;
using Povio.FlowerSpot.Application.Features.Sightings.Commands.Dislike;
using Povio.FlowerSpot.Application.Features.Sightings.Commands.Like;
using Povio.FlowerSpot.Application.Features.Sightings.Queries.GetNumberOfLikes;

namespace Povio.FlowerSpot.Api.Controllers
{
    [Route("api/sightings/{sightingId:int:min(1)}/likes")]
    public class LikeController : ApplicationController
    {
        public LikeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sightingId)
        {
            var response = await Mediator.Send(new GetNumberOfLikesQuery(sightingId), HttpContext.RequestAborted);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int sightingId)
        {
            await Mediator.Send(new LikeCommand(sightingId, CurrentUserId), HttpContext.RequestAborted);

            return CreatedAtAction(nameof(Post), new
            {
                sightingId,
                userId = CurrentUserId
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int sightingId)
        {
            await Mediator.Send(new DislikeCommand(sightingId, CurrentUserId), HttpContext.RequestAborted);

            return NoContent();
        }
    }
}
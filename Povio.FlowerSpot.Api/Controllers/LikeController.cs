using MediatR;
using Microsoft.AspNetCore.Mvc;
using Povio.FlowerSpot.Api.Controllers.Common;

namespace Povio.FlowerSpot.Api.Controllers
{
    [Route("api/sightings/{sightingId:int:min(1)}/likes")]
    public class LikeController : ApplicationController
    {
        public LikeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public IActionResult Post(int sightingId)
        {
            return CreatedAtAction(nameof(Post), new { });
        }

        [HttpDelete]
        public IActionResult Delete(int sightingId)
        {
            return NoContent();
        }
    }
}
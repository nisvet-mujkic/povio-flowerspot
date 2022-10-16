using MediatR;
using Microsoft.AspNetCore.Mvc;
using Povio.FlowerSpot.Api.Controllers.Common;

namespace Povio.FlowerSpot.Api.Controllers
{
    [Route("api/sightings")]
    public class SightingController : ApplicationController
    {
        public SightingController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // TODO: Endpoint to get number of likes

        [HttpPost]
        public IActionResult Post()
        {
            return CreatedAtAction(nameof(Post), new { });
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return NoContent();
        }
    }
}
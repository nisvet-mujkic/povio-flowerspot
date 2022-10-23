using MediatR;
using Microsoft.AspNetCore.Mvc;
using Povio.FlowerSpot.Api.Controllers.Common;
using Povio.FlowerSpot.Application.Features.Sightings.Commands.Create;
using Povio.FlowerSpot.Application.Features.Sightings.Commands.Delete;
using Povio.FlowerSpot.Application.Features.Sightings.Queries.GetSightings;
using Povio.FlowerSpot.Contracts.Responses.Sightings;
using System.Security.Claims;

namespace Povio.FlowerSpot.Api.Controllers
{
    [Route("api/sightings")]
    public class SightingController : ApplicationController
    {
        public SightingController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetSightingsResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var sightings = await Mediator.Send(new GetSightingsQuery(), HttpContext.RequestAborted);

            return Ok(sightings);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateSightingResponse))]
        public async Task<IActionResult> Post(CreateCommand command)
        {
            var response = await Mediator.Send(command, HttpContext.RequestAborted);

            return CreatedAtAction(nameof(Post), response);
        }

        [HttpDelete("{sightingId:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int sightingId)
        {
            await Mediator.Send(new DeleteCommand(sightingId, CurrentUserId), HttpContext.RequestAborted);

            return NoContent();
        }
    }
}
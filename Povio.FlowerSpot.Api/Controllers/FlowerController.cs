using MediatR;
using Microsoft.AspNetCore.Mvc;
using Povio.FlowerSpot.Api.Controllers.Common;
using Povio.FlowerSpot.Application.Features.Flowers.Commands.Create;
using Povio.FlowerSpot.Application.Features.Flowers.Queries;
using Povio.FlowerSpot.Contracts.Responses.Flowers;

namespace Povio.FlowerSpot.Api.Controllers
{
    [Route("api/flowers")]
    public class FlowerController : ApplicationController
    {
        public FlowerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetFlowersResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var response = await Mediator.Send(new GetFlowersQuery(), HttpContext.RequestAborted);

            return response.Match<ActionResult>(
                Ok,
                _ => NotFound());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(CreateFlowerCommand command)
        {
            await Mediator.Send(command, HttpContext.RequestAborted);

            return Ok();
        }
    }
}
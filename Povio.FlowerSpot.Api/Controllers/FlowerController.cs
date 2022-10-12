using MediatR;
using Microsoft.AspNetCore.Mvc;
using Povio.FlowerSpot.Application.Features.Flowers.Queries;
using Povio.FlowerSpot.Contracts.Responses.Flowers;

namespace Povio.FlowerSpot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlowerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetFlowersResponse>> Get()
        {
            var response = await _mediator.Send(new GetFlowersQuery(), HttpContext.RequestAborted);

            return response.Match<ActionResult>(
                Ok,
                _ => NotFound());
        }
    }
}

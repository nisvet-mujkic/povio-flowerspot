using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Povio.FlowerSpot.Api.Controllers.Common;
using Povio.FlowerSpot.Application.Features.Flowers.Commands.Create;
using Povio.FlowerSpot.Application.Features.Flowers.Queries.GetFlowers;
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
        public async Task<Result<GetFlowersResponse>> Get()
            => await Mediator.Send(new GetFlowersQuery(), HttpContext.RequestAborted);

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateFlowerResponse))]
        public async Task<Result<CreateFlowerResponse>> Post(CreateFlowerCommand command)
            => await Mediator.Send(command, HttpContext.RequestAborted);
    }
}
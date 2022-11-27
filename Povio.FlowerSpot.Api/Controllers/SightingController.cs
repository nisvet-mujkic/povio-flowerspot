using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Povio.FlowerSpot.Api.Controllers.Common;
using Povio.FlowerSpot.Application.Features.Sightings.Commands.Create;
using Povio.FlowerSpot.Application.Features.Sightings.Commands.Delete;
using Povio.FlowerSpot.Application.Features.Sightings.Queries.GetSightings;
using Povio.FlowerSpot.Contracts.Requests.Sightings;
using Povio.FlowerSpot.Contracts.Responses.Sightings;

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
        public async Task<Result<GetSightingsResponse>> Get() 
            => await Mediator.Send(new GetSightingsQuery(), HttpContext.RequestAborted);

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateSightingResponse))]
        public async Task<Result<CreateSightingResponse>> Post(CreateSightingRequest request)
            => await Mediator.Send(
                new CreateCommand(request.Longitude, request.Latitude, CurrentUserId, request.FlowerId, request.ImageRef), 
                    HttpContext.RequestAborted);

        [HttpDelete("{sightingId:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<Result> Delete(int sightingId)
            => await Mediator.Send(new DeleteCommand(sightingId, CurrentUserId), HttpContext.RequestAborted);
    }
}
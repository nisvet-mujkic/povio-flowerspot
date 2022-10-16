using MediatR;
using Microsoft.AspNetCore.Mvc;
using Povio.FlowerSpot.Api.Controllers.Common;

namespace Povio.FlowerSpot.Api.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : ApplicationController
    {
        public AuthenticationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
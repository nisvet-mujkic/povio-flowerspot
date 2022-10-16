using MediatR;
using Microsoft.AspNetCore.Mvc;
using Povio.FlowerSpot.Api.Controllers.Common;

namespace Povio.FlowerSpot.Api.Controllers
{
    [Route("api/users")]
    public class UserController : ApplicationController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
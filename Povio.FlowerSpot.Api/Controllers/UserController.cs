using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Povio.FlowerSpot.Api.Controllers.Common;
using Povio.FlowerSpot.Application.Features.Users.Commands.Register;

namespace Povio.FlowerSpot.Api.Controllers
{
    [Route("api/users")]
    public class UserController : ApplicationController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(RegisterUserCommand command)
        {
            var response = await Mediator.Send(command, HttpContext.RequestAborted);

            return response.Match<IActionResult>(
                success => CreatedAtAction(nameof(Post), command),
                _ => BadRequest());
        }
    }
}
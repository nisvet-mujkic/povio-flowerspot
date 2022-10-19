using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Povio.FlowerSpot.Api.Controllers.Common
{
    [Authorize]
    [ApiController]
    public abstract class ApplicationController : ControllerBase
    {
        public ApplicationController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IMediator Mediator { get; }

        protected int CurrentUserId => 
            int.Parse(HttpContext.User.Claims.Single(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
    }
}

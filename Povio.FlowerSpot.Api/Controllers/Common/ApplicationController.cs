using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Povio.FlowerSpot.Api.Extensions;
using System.Security.Claims;

namespace Povio.FlowerSpot.Api.Controllers.Common
{
    [Authorize]
    [ApiController]
    [TranslateResultToActionResult]
    public abstract class ApplicationController : ControllerBase
    {
        public ApplicationController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IMediator Mediator { get; }

        protected int CurrentUserId =>
            int.TryParse(HttpContext.GetClaimValue(ClaimTypes.NameIdentifier), out int id) ? id : default;
    }
}
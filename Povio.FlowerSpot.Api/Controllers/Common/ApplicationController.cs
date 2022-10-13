using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Povio.FlowerSpot.Api.Controllers.Common
{
    [ApiController]
    public abstract class ApplicationController : ControllerBase
    {
        public ApplicationController(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }
    }
}

using Application.CQRS.Profile.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Profile : ControllerBase
    {
        private readonly IMediator _mediator;

        public Profile(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _mediator.Send(new GetProfileCommand());
            return Ok(result);
        }
    }
}

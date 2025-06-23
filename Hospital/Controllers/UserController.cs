using Application.CQRS.User.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll(GetAllUserCommand request , CancellationToken cancellation)
        {
            var result = _mediator.Send(request, cancellation);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(GetUserByIdCommand request , CancellationToken cancellationToken)
        {
            var result = _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CraeteUser()
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult Edit()
        {
            return Ok();
        }
    }
}

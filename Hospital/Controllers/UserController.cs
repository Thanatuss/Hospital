using Application.CQRS.User.Command;
using Application.CQRS.User.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll( CancellationToken cancellation)
        {
            var request = new GetAllUserCommand { };
            var result = await _mediator.Send(request , cancellation);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(GetUserByIdCommand request , CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
        [HttpPost("Create")]
        public IActionResult CraeteUser([FromQuery]CreateUserCommand request , CancellationToken cancellationToken)
        {
            var result = _mediator.Send(request , cancellationToken);
            return Ok(request);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(DeleteUserCommand requst , CancellationToken cancellationToken)
        {
            var result = _mediator.Send(requst, cancellationToken);
            return Ok(result);
        }
        [HttpPut("Edit")]
        public IActionResult Edit()
        {
            return Ok();
        }
    }
}

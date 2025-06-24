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
        public IActionResult CraeteUser()
        {
            return Ok();
        }
        [HttpDelete("Delete")]
        public IActionResult Delete()
        {
            return Ok();
        }
        [HttpPut("Edit")]
        public IActionResult Edit()
        {
            return Ok();
        }
    }
}

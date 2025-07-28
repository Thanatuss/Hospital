using Application.CQRS.User.Command;
using Application.CQRS.User.Query;
using Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        public async Task<IActionResult> GetAll(CancellationToken cancellation)
        {
            var request = new GetAllUserCommand { };
            var result = await _mediator.Send(request, cancellation);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var command = new GetUserByIdCommand
            {
                Id = id
            };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CraeteUser([FromBody] CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(request.createUser);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteUserCommand requst, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(requst, cancellationToken);
            return Ok(result);
        }
        [HttpPut("Edit")]
        public IActionResult Edit()
        {
            return Ok();
        }
        [HttpPut("Login")]
        public async Task<IActionResult> Login(string Fullname, string nationalCode)
        {
            var request = await _mediator.Send(new LoginCommand
            {
                Fullname = Fullname , 
                Nationalcode = nationalCode
            });
            return Ok(request);
        }

    }
}

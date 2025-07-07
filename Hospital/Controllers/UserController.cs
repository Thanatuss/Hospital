using Application.CQRS.User.Command;
using Application.CQRS.User.Query;
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
        public IActionResult Login(string Fullname, string nationalCode)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name , Fullname),
                new Claim(ClaimTypes.Name , nationalCode)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyThatIsLongEnoughToBeSecure123!!"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "Hospital",
                audience: "Admin",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = jwt});
        }

    }
}

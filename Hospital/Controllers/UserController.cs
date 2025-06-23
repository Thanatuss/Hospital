using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok();
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

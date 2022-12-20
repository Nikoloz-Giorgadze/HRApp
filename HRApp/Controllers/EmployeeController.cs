using ApplicationCQRS.Commands.EmployeeC;
using ApplicationCQRS.Queries;
using ApplicationDtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase

    {
        private readonly IMediator _mediator = default;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet()]
        public async Task<IEnumerable<EmployeeDto>> Get(string UserName)
        {
            var Query = new ReadAllEmployeeQuery() { Username = UserName };
            return await _mediator.Send(Query);
        }

        // GET api/<UserController>/5
        [HttpGet("{Id}")]
        public async Task<EmployeeDto> Get(int Id)
        {
            var readById = new ReadEmployeeByIdQuery() { Id = Id };
            return (EmployeeDto)await _mediator.Send(readById);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDto value, string UserName)
        {

            if (value == null) { return BadRequest(); }

            var command = new AddEmployeeCommand() { EmployeeDto = value, UserName = UserName };
            var result = await _mediator.Send(command);
            if (result)
                return Ok(value);

            ModelState.AddModelError("error:500", "Server side exception :((");
            return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDto value)
        {
            if (value == null) { return BadRequest(); }

            var command = new UpdateEmployeeCommand() { Id = id, Employee = value };
            var result = await _mediator.Send(command);
            if (result)
                return Ok(value);

            ModelState.AddModelError("error:500", "Server side exception :((");
            return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteEmployeeCommand() { Id = id, };
            var result = await _mediator.Send(command);
            if (result)
                return Ok();

            ModelState.AddModelError("error:500", "Server side exception :((");
            return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
        }
    }


}

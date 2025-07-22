using Application.Abstractions.Ports.Handlers;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Route("/api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromServices] ICommandHandler<Command.CreateAccountCommand> handler,
            [FromBody] Command.CreateAccountCommand command, 
            CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return BadRequest("Command cannot be null.");
            }

            try
            {
                await handler.Handle(command, cancellationToken);
                return Ok("Account created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

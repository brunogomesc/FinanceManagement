using Application.Abstractions.Ports.Handlers;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BudgetController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(
            [FromServices] ICommandHandler<Command.RegisterBudgetCommand> handler,
            [FromBody] Command.RegisterBudgetCommand command,
            CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return BadRequest("Command cannot be null.");
            }

            try
            {
                await handler.Handle(command, cancellationToken);
                return Ok("Budget created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("category")]
        public async Task<IActionResult> AddCategoryAsync(
            [FromServices] ICommandHandler<Command.AddCategoryCommand> handler,
            [FromBody] Command.AddCategoryCommand command,
            CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return BadRequest("Command cannot be null.");
            }

            try
            {
                await handler.Handle(command, cancellationToken);
                return Ok("Category created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("category/{accountId}")]
        public async Task<IActionResult> ListCategoryAsync(
            [FromServices] IQueryHandler<Query.ListCategoryQuery, List<ViewModel.CategoryViewModel>> handler,
            [FromRoute] Guid accountId,
            CancellationToken cancellationToken)
        {
            if (accountId == Guid.Empty)
            {
                return BadRequest("AccountId cannot be null.");
            }

            try
            {
                var categories = await handler.Handle(new Query.ListCategoryQuery(accountId), cancellationToken);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

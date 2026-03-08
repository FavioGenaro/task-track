using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// [Authorize]
[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        // var userId = Guid.Parse(User.FindFirst("sub")!.Value);
        // var userId = new Guid("00000000-0000-0000-0000-000000000001");

        var userId = Guid.Parse("00000000-0000-0000-0000-000000000001");

        var result = await _mediator.Send(
            new GetTaskByIdQuery(id, userId));

        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // var userId = Guid.Parse(User.FindFirst("sub")!.Value);
        var userId = Guid.Parse("00000000-0000-0000-0000-000000000001");


        var result = await _mediator.Send(
            new GetTasksByUserQuery(userId));

        // return Ok(); // result
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        // var userId = Guid.Parse(User.FindFirst("sub")!.Value);
        var userId = Guid.Parse("00000000-0000-0000-0000-000000000001");


        var result = await _mediator.Send(
            new DeleteTaskByIdCommand(id, userId));

        if (result is null)
        {
            return NotFound();
        }
        
        return Ok();
    }
}

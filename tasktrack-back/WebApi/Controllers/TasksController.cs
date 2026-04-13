using Aplicacion.DTOs.ChangeStatus;
using MediatR;
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
        var userId = Guid.Parse("9D71DFA7-BA01-43B5-A995-5B2B96A23EF5");


        var result = await _mediator.Send(
            new GetTasksByUserQuery(userId));

        // return Ok(); // result
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask(CreateTaskCommand command)
    {
        // var userId = Guid.Parse(User.FindFirst("sub")!.Value);
        // var userId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        // command.UserId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        
        var result = await _mediator.Send(
            new CreateTaskCommand(
                command.Title,
                command.Description,
                command.DueDate,
                command.Status,
                command.UserId,
                command.Priority
            ));

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

        if (result is false)
        {
            return NotFound();
        }
        
        return Ok();
    }

    [HttpPatch("{id:guid}", Name ="ChangeStatus")]
    public async Task<IActionResult> ChangeStatus(Guid id, ChangeStatusDto status)
    {
        // var userId = Guid.Parse(User.FindFirst("sub")!.Value);
        var userId = Guid.Parse("00000000-0000-0000-0000-000000000001");

        var result = await _mediator.Send(
            new ChangeStatusByIdCommand(id, userId, status.TaskStatus));

        if (result is false)
        {
            return NotFound();
        }
        
        return Ok();
    }
}

using System.Security.Claims;
using Aplicacion.DTOs.ChangeStatus;
using Aplicacion.DTOs.Input;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICurrentUserService currentUser; // para acceder al contexto HTTP

    public TasksController(IMediator mediator, ICurrentUserService currentUser)
    {
        _mediator = mediator;
        this.currentUser = currentUser;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var claimUserId = currentUser.UserId;
        if(claimUserId is null)
        {
            return Unauthorized();
        }

        var userId = claimUserId.Value;

        var result = await _mediator.Send(
            new GetTaskByIdQuery(id, userId));

        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        var claimUserId = currentUser.UserId;
        if(claimUserId is null)
        {
            return Unauthorized();
        }

        var userId = claimUserId.Value;

        var result = await _mediator.Send(
            new GetTasksByUserQuery(userId));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask(
        // CreateTaskCommand command}
        TaskDto taskDto
    )
    {
        var claimUserId = currentUser.UserId;
        if(claimUserId is null)
        {
            return Unauthorized();
        }

        var userId = claimUserId.Value;
        
        var result = await _mediator.Send(
            new CreateTaskCommand(
                taskDto.Title,
                taskDto.Description,
                taskDto.DueDate,
                taskDto.Status,
                taskDto.Priority,
                taskDto.TagIds,
                userId
            )
        );

        // retornamos la tarea creada
        var task = await _mediator.Send(
            new GetTaskByIdQuery(result, userId));

        return task is null ? NotFound() : Ok(task);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        var claimUserId = currentUser.UserId;
        if(claimUserId is null)
        {
            return Unauthorized();
        }

        var userId = claimUserId.Value;


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
        var claimUserId = currentUser.UserId;
        if(claimUserId is null)
        {
            return Unauthorized();
        }

        var userId = claimUserId.Value;

        var result = await _mediator.Send(
            new ChangeStatusByIdCommand(id, userId, status.TaskStatus));

        if (result is false)
        {
            return NotFound();
        }
        
        return Ok();
    }
}

using Aplicacion.DTOs.Input;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/tags")]
public class TagController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICurrentUserService currentUser; // para acceder al contexto HTTP


    public TagController(IMediator mediator, ICurrentUserService currentUser)
    {
        _mediator = mediator;
        this.currentUser = currentUser;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var claimUserId = currentUser.UserId;
        if(claimUserId is null)
        {
            return Unauthorized();
        }

        var user = await _mediator.Send(new GetUserByIdQuery(claimUserId.Value));
        
        if(user is null)
        {
            return Unauthorized();
        }
        var result = await _mediator.Send(
            new GetTagsByUserQuery(claimUserId.Value));

        // return Ok(); // result
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTag(CreateTagDto createTagDto)
    {

        var claimUserId = currentUser.UserId;
        if(claimUserId is null)
        {
            return Unauthorized();
        }

        var user = await _mediator.Send(new GetUserByIdQuery(claimUserId.Value));
        
        if(user is null)
        {
            return Unauthorized();
        }


        var result = await _mediator.Send(
            new CreateTagCommand(
                claimUserId.Value,
                createTagDto.Name,
                createTagDto.Color
            ));

        // return Ok(); // result
        return Ok(result);
    }
}

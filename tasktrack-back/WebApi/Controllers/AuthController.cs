using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// [Authorize]
[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        // try
        // {
            
        // }
        // catch (System.Exception)
        // {
            
        //     throw ;
        // }

        var user = await _mediator.Send(command);

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var user = await _mediator.Send(command);

        return Ok(user);
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;

// [Authorize]
[ApiController]
[Route("api/tags")]
public class TagController : ControllerBase
{
    private readonly IMediator _mediator;

    public TagController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // [HttpGet]
    // public async Task<IActionResult> GetAll()
    // {
    //     // var userId = Guid.Parse(User.FindFirst("sub")!.Value);
    //     var userId = Guid.Parse("9D71DFA7-BA01-43B5-A995-5B2B96A23EF5");


    //     var result = await _mediator.Send(
    //         new GetTasksByUserQuery(userId));

    //     // return Ok(); // result
    //     return Ok(result);
    // }

    [HttpPost]
    public async Task<IActionResult> CreateTag(CreateTagCommand command)
    {
        var result = await _mediator.Send(command);

        // return Ok(); // result
        return Ok(result);
    }
}

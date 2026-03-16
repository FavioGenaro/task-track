using MediatR;

public record DeleteTaskByIdCommand( Guid TaskId, Guid UserId)
    : IRequest<bool>;
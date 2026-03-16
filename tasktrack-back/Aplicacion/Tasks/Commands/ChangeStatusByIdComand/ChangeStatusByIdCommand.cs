using MediatR;

public record ChangeStatusByIdCommand(Guid TaskId, Guid UserId, Dominio.Enums.TaskStatus NewStatus)
    : IRequest<bool>;
using MediatR;

public record CreateTaskCommand(
    string Title,
    string? Description,
    DateTime? DueDate,
    Dominio.Enums.TaskStatus Status,
    Dominio.Enums.TaskPriority Priority,
    List<Guid> TagIds,
    Guid UserId
) : IRequest<Guid>;
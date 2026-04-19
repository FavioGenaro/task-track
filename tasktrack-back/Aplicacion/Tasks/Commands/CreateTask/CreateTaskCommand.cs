using MediatR;
using Aplicacion.DTOs.Tasks;

public record CreateTaskCommand(
    // Guid Id,
    string Title,
    string? Description,
    DateTime? DueDate,
    Dominio.Enums.TaskStatus Status,
    // bool IsArchived,
    Guid UserId,
    Dominio.Enums.TaskPriority Priority,
    List<Guid> TagIds
) : IRequest<TaskDto>;
using Aplicacion.DTOs.Tasks;
using MediatR;

public record GetTaskByIdQuery(Guid TaskId, Guid UserId)
    : IRequest<TaskDto?>;
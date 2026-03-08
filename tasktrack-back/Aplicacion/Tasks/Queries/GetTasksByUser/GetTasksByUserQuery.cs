using Aplicacion.DTOs.Tasks;
using MediatR;

public record GetTasksByUserQuery(Guid UserId)
    : IRequest<IReadOnlyList<TaskDto>>;
using Aplicacion.DTOs.Tasks;
using MediatR;

public record DeleteTaskByIdCommand( Guid TaskId, Guid UserId)
    : IRequest<int?>;
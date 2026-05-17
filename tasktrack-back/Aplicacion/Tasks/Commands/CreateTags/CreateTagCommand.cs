using MediatR;
using Aplicacion.DTOs;

public record CreateTagCommand(
    Guid UserId,
    string Name,
    string Color
) : IRequest<TagsDto>;
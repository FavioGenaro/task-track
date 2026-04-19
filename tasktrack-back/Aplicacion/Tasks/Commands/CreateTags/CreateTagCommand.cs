using MediatR;
using Aplicacion.DTOs;

public record CreateTagCommand(
    string Name,
    string Color
) : IRequest<TagsDto>;
using MediatR;
using Aplicacion.DTOs.TagsDto;

public record CreateTagCommand(
    string Name,
    string Color
) : IRequest<TagsDto>;
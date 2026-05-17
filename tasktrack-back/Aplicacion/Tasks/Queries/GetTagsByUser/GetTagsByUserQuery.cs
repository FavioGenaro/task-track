using Aplicacion.DTOs;
using Aplicacion.DTOs.Tasks;
using MediatR;

public record GetTagsByUserQuery(Guid UserId)
    : IRequest<IReadOnlyList<TagsDto>>;
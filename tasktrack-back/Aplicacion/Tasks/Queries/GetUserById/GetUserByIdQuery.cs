using Aplicacion.DTOs.User;
using MediatR;
public record GetUserByIdQuery(Guid UserId): IRequest<UserDto?>;
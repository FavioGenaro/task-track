using Aplicacion.DTOs.User;
using MediatR;

public record LoginQuery(
    string Email,
    string Password
) : IRequest<UserDto>;
using Aplicacion.DTOs.User;
using MediatR;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<UserResponseDto>;
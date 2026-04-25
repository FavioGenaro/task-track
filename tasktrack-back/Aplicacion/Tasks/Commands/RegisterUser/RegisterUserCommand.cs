using Aplicacion.DTOs.User;
using MediatR;

public record RegisterUserCommand(
    string Email,
    string Password,
    string FullName
) : IRequest<UserResponseDto>;
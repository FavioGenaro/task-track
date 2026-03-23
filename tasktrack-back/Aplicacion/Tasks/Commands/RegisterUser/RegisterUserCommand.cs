using MediatR;

public record RegisterUserCommand(
    string Email,
    string Password,
    string FullName
) : IRequest<Guid>;
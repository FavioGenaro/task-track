using Aplicacion.DTOs.User;
using AutoMapper;
using MediatR;

public class LoginHandler
    : IRequestHandler<LoginQuery, UserDto>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public LoginHandler(
        IUserRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(
        LoginQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _repository.GetByEmailAsync(request.Email);

        if (user == null)
            throw new Exception("Invalid credentials");

        var valid =
            BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash);

        if (!valid)
            throw new Exception("Invalid credentials");

        var userDto = new UserDto
        {
            Email = user.Email,
            FullName = user.FullName,
            AvatarUrl = user.AvatarUrl,
            isActive = user.isActive
        };

        return userDto;
    }
}
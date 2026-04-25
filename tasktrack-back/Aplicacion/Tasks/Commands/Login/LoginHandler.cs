using Aplicacion.DTOs.User;
using AutoMapper;
using MediatR;

public class LoginHandler
    : IRequestHandler<LoginCommand, UserResponseDto>
{
    private readonly IUserRepository _repository;
    private readonly IJwtTokenService _jwtService;
    private readonly IMapper _mapper;

    public LoginHandler(
        IUserRepository repository,
        IJwtTokenService jwtService,
        IMapper mapper)
    {
        _repository = repository;
        _jwtService = jwtService;
        _mapper = mapper;
    }

    public async Task<UserResponseDto> Handle(
        LoginCommand request,
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

        var token = _jwtService.GenerateToken(user);

        var userDto = _mapper.Map<UserDto>(user);

        var loginResponseDto = new UserResponseDto
        {
            Token = token,
            UserDto = userDto
        };

        return loginResponseDto;
    }
}
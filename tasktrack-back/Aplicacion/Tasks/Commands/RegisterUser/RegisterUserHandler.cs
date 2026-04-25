using MediatR;
using AutoMapper;
using Dominio.Entities;
using Aplicacion.DTOs.User;
public class RegisterUserHandler
    : IRequestHandler<RegisterUserCommand, UserResponseDto>
{
    private readonly IUserRepository _repository;
    private readonly IJwtTokenService _jwtService;
    private readonly IMapper _mapper;

    public RegisterUserHandler(IUserRepository repository,
        IJwtTokenService jwtService,
        IMapper mapper
    )
    {
        _repository = repository;
        _jwtService = jwtService;
        _mapper = mapper;
    }

    public async Task<UserResponseDto> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByEmailAsync(request.Email);

        if (existing != null)
            throw new Exception("Email already registered");

        var userId = Guid.NewGuid();

        var userPreferences = new UserPreferences
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            ThemesEnum = Dominio.Enums.ThemesEnum.Light,
            CreatedAt = DateTime.UtcNow,
        };

        var user = new User
        {
            Id = userId,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            FullName = request.FullName,
            AvatarUrl = "",
            isActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            UserPreferences = userPreferences
        };

        await _repository.AddAsync(user);

        var userDto = _mapper.Map<UserDto>(user);
        var token = _jwtService.GenerateToken(user);

        var loginResponseDto = new UserResponseDto
        {
            Token = token,
            UserDto = userDto
        };

        return loginResponseDto;
    }
}
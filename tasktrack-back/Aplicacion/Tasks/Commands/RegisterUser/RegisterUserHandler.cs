using MediatR;
using AutoMapper;
using Dominio.Entities;
using Aplicacion.DTOs.User;
public class RegisterUserHandler
    : IRequestHandler<RegisterUserCommand, UserDto>
{
    private readonly IUserRepository _repository;
    private readonly IUserPreferencesRepository _repositoryUserPreferences;
    private readonly IMapper _mapper;

    public RegisterUserHandler(IUserRepository repository, IUserPreferencesRepository repositoryUserPreferences, IMapper mapper)
    {
        _repository = repository;
        _repositoryUserPreferences = repositoryUserPreferences;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(
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

        // return user.Id;
        return userDto;
    }
}
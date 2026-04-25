using Aplicacion.DTOs.User;

public class UserResponseDto
{
    public string Token { get; set; } = null!;
    public UserDto UserDto { get; set; } = null!;
}
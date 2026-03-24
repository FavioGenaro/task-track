namespace Aplicacion.DTOs.User;

public class UserDto
{
    public required string Email { get; set; }
    public string FullName { get; set; } = null!;
    public string? AvatarUrl { get; set; }
    public bool isActive { get; set; }
}
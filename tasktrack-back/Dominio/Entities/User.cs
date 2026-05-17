namespace Dominio.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string FullName { get; set; }
    public required string AvatarUrl { get; set; }
    public bool isActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // public ICollection<Task> Tasks { get; set; }
    public ICollection<Tags> Tags { get; set; } = new List<Tags>();

    public required UserPreferences UserPreferences { get; set; }
}

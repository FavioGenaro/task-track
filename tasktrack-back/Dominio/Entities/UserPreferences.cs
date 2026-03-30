namespace Dominio.Entities;

public class UserPreferences
{
    public Guid Id { get; set; }

    public Enums.ThemesEnum ThemesEnum { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;
}

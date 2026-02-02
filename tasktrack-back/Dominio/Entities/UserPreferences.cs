namespace Dominio.Entities;

public class UserPreferences
{
    public Guid Id { get; set; }

    public enum Theme {
        Light, Dark
    }
    
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
}

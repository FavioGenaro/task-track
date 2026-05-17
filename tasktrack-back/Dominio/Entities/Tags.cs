namespace Dominio.Entities;

public class Tags
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Color { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public ICollection<TagsTask> Tasks { get; set; } = new List<TagsTask>();
}

namespace Aplicacion.DTOs.Input;

public class TaskDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public Dominio.Enums.TaskStatus Status { get; set; }
    public Dominio.Enums.TaskPriority Priority { get; set; }
    public List<Guid> TagIds { get; set; } = new List<Guid>();

    // public Guid UserId { get; set; }
}
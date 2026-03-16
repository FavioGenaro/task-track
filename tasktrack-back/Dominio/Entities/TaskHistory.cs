namespace Dominio.Entities;

public class TaskHistory
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public Enums.TaskStatus PreviousStatus { get; set; }
    public Enums.TaskStatus NewStatus { get; set; }
    public DateTime ChangedAt { get; set; }
}

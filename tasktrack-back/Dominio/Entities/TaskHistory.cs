namespace Dominio.Entities;

public class TaskHistory
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public TaskStatus PreviousStatus { get; set; }
    public TaskStatus NewStatus { get; set; }
    public DateTime ChangedAt { get; set; }
}

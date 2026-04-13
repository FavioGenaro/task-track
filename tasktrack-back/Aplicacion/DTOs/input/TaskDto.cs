namespace Aplicacion.DTOs.Input;

public class TaskDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public string Status { get; set; } = null!;
    public string Priority { get; set; } = null!;

    public Guid UserId { get; set; }
}
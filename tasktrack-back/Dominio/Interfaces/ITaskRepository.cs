namespace Dominio.Interfaces;

public interface ITaskRepository
{
    Task<Entities.Task?> GetByIdAsync(Guid taskId, Guid userId);

    Task<IReadOnlyList<Entities.Task>> GetByUserAsync(Guid userId);

    Task<bool> DeleteByIdAsync(Guid taskId, Guid userId);

    Task<bool> ChangeStatusByIdAsync(Guid taskId, Guid userId, Enums.TaskStatus newStatus);

    Task<Entities.Task> AddAsync(Entities.Task task);

    Task UpdateAsync(Entities.Task task);
}

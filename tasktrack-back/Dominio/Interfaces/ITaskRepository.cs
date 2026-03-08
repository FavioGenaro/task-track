namespace Dominio.Interfaces;

public interface ITaskRepository
{
    // Task<IEnumerable<Task>> GetByUser(Guid userId);
    // Task Add(Task task);
    // Task Update(Task task);
    // Task Delete(Guid id);

    Task<Entities.Task?> GetByIdAsync(Guid taskId, Guid userId);
    Task<IReadOnlyList<Entities.Task>> GetByUserAsync(Guid userId);
    Task<int?> DeleteByIdAsync(Guid taskId, Guid userId);
}

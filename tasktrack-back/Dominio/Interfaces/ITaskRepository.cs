namespace Dominio.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<Task>> GetByUser(Guid userId);
    Task Add(Task task);
    Task Update(Task task);
    Task Delete(Guid id);
}

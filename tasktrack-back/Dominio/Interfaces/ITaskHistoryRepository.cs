public interface ITaskHistoryRepository
{
    Task AddAsync(Dominio.Entities.TaskHistory history);

    Task<IReadOnlyList<Dominio.Entities.TaskHistory>> GetByTaskIdAsync(Guid taskId);
}
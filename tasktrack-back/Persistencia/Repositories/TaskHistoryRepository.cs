using Microsoft.EntityFrameworkCore;
using Persistencia;

public class TaskHistoryRepository : ITaskHistoryRepository
{
    private readonly TaskTrackContext _context;

    public TaskHistoryRepository(TaskTrackContext context)
    {
        _context = context;
    }

    public async Task AddAsync( Dominio.Entities.TaskHistory history)
    {
        await _context.TaskHistory.AddAsync(history);

        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList< Dominio.Entities.TaskHistory>> GetByTaskIdAsync(Guid taskId)
    {
        return await _context.TaskHistory
            .AsNoTracking()
            .Where(h => h.TaskId == taskId)
            .OrderByDescending(h => h.ChangedAt)
            .ToListAsync();
    }
}
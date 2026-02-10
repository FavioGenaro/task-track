using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

public class TaskRepository : ITaskRepository
{
    private readonly TaskTrackContext _context;

    public TaskRepository(TaskTrackContext context)
    {
        _context = context;
    }

    public async Task<Dominio.Entities.Task?> GetByIdAsync(Guid taskId, Guid userId)
    {
        return await _context.Tasks
            .FirstOrDefaultAsync(t =>
                t.Id == taskId // &&
                // t.UserId == userId &&
                // !t.IsArchived
                );
    }

    // public async Task<IReadOnlyList<Dominio.Entities.Task>> GetByUserAsync(Guid userId)
    // {
    //     return await _context.Tasks
    //         .Where(t => t.UserId == userId && !t.IsArchived)
    //         // .OrderBy(t => t.Position)
    //         .ToListAsync();
    // }
}

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

    public async Task<IReadOnlyList<Dominio.Entities.Task>> GetByUserAsync(Guid userId)
    {
        return await _context.Tasks
            .Where(t => t.UserId == userId 
                // && !t.IsArchived
            )
            // .OrderBy(t => t.Position)
            .ToListAsync();
    }

    // eliminar tarea
    public async Task<int?> DeleteByIdAsync(Guid taskId, Guid userId)
    {
        var task = await _context.Tasks
            .FirstOrDefaultAsync(t =>
                t.Id == taskId // &&
                // t.UserId == userId &&
                // !t.IsArchived
                );
        
        if(task is null) return null;
        
        task.IsArchived = true;

        _context.Update(task);
        
        return await _context.SaveChangesAsync();
    }
}

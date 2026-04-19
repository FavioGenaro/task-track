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
            .Include(t => t.Tags)
                .ThenInclude(tt => tt.Tag)
            .FirstOrDefaultAsync(t =>
                t.Id == taskId &&
                t.UserId == userId // &&
                // !t.IsArchived
                );
    }

    public async Task<IReadOnlyList<Dominio.Entities.Task>> GetByUserAsync(Guid userId)
    {
        return await _context.Tasks
            .Include(t => t.Tags)
                .ThenInclude(tt => tt.Tag)
            .Where(t => t.UserId == userId 
                // && !t.IsArchived
            )
            // .OrderBy(t => t.Position)
            .ToListAsync();
    }

    // eliminar tarea
    public async Task<bool> DeleteByIdAsync(Guid taskId, Guid userId)
    {
        var task = await _context.Tasks
            .FirstOrDefaultAsync(t =>
                t.Id == taskId // &&
                // t.UserId == userId &&
                // !t.IsArchived
                );
        
        if(task is null) return false;
        
        task.IsArchived = true;
        task.UpdatedAt = DateTime.UtcNow;

        _context.Update(task);

        await _context.SaveChangesAsync();
        
        return true;
    }

    // cambiar estado de la tarea
    public async Task<bool> ChangeStatusByIdAsync(Guid taskId, Guid userId, Dominio.Enums.TaskStatus newStatus)
    {
        var task = await _context.Tasks
            .FirstOrDefaultAsync(t =>
                t.Id == taskId // &&
                // t.UserId == userId &&
                // !t.IsArchived
                );
        
        if(task is null) return false;

        task.Status = newStatus;
        task.UpdatedAt = DateTime.UtcNow;

        _context.Update(task);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<Dominio.Entities.Task> AddAsync(Dominio.Entities.Task task)
    {
        await _context.Tasks.AddAsync(task);

        await _context.SaveChangesAsync();

        return task;
    }

    public async Task UpdateAsync(Dominio.Entities.Task task)
    {
        task.UpdatedAt = DateTime.UtcNow;
        _context.Tasks.Update(task);

        await _context.SaveChangesAsync();
        
    }
}

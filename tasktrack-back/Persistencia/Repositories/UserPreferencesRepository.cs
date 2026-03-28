// using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

public class UserPreferencesRepository : IUserPreferencesRepository
{
    private readonly TaskTrackContext _context;

    public UserPreferencesRepository(TaskTrackContext context)
    {
        _context = context;
    }

    public async Task<Dominio.Entities.UserPreferences?> GetByUserIdAsync(Guid userId)
    {
        return await _context.UserPreferences
            .FirstOrDefaultAsync(p => p.UserId == userId);
    }

    public async Task AddAsync(Dominio.Entities.UserPreferences preferences)
    {
        await _context.UserPreferences.AddAsync(preferences);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Dominio.Entities.UserPreferences preferences)
    {
        _context.UserPreferences.Update(preferences);

        await _context.SaveChangesAsync();
    }
}
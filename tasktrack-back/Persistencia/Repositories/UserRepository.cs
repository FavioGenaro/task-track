using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Persistencia;

public class UserRepository : IUserRepository
{
    private readonly TaskTrackContext _context;

    public UserRepository(TaskTrackContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.User
            .Include(t => t.UserPreferences)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.User
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> AddAsync(User user)
    {
        await _context.User.AddAsync(user);

        await _context.SaveChangesAsync();

        return user;
    }
}
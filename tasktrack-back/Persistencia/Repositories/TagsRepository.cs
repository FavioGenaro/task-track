using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Persistencia;

public class TagsRepository : ITagsRepository
{
    private readonly TaskTrackContext _context;

    public TagsRepository(TaskTrackContext context)
    {
        _context = context;
    }

    public async Task<Tags> AddAsync(Tags tag) 
    {
        await _context.Tags.AddAsync(tag);

        await _context.SaveChangesAsync();

        return tag;
    }

    public async Task<IReadOnlyList<Tags>> GetByUserAsync(Guid userId)
    {
        return await _context.Tags
            // .Include(t => t.Tags)
            //     .ThenInclude(tt => tt.Tag)
            .Where(t => t.UserId == userId)
            .ToListAsync();
    }
}

using Dominio.Entities;
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
}

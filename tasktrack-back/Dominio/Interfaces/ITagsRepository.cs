
public interface ITagsRepository
{
    Task<Dominio.Entities.Tags> AddAsync(Dominio.Entities.Tags tag);
    Task<IReadOnlyList<Dominio.Entities.Tags>> GetByUserAsync(Guid userId);

    // Task UpdateAsync(Dominio.Entities.UserPreferences preferences);
}
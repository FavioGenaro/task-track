
public interface ITagsRepository
{
    Task<Dominio.Entities.Tags> AddAsync(Dominio.Entities.Tags tag);

    // Task UpdateAsync(Dominio.Entities.UserPreferences preferences);
}
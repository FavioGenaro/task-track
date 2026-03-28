// using Dominio.Entities;
public interface IUserPreferencesRepository
{
    Task<Dominio.Entities.UserPreferences?> GetByUserIdAsync(Guid userId);

    Task AddAsync(Dominio.Entities.UserPreferences preferences);

    Task UpdateAsync(Dominio.Entities.UserPreferences preferences);
}
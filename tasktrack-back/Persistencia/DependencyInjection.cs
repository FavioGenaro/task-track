using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistencia;

// esta clase es la encargada de registrar las dependencias de la capa de persistencia,
// esta clase es una clase estática, esto significa que no se puede instanciar.

public static class DependencyInjection
{
    // AddPersistence es un método de extensión que se encarga de registrar las dependencias 
    // de la capa de persistencia,
    // este método recibe como parámetros el contenedor de servicios y la configuración de la aplicación,
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        //  Configura EF‑Core y registra los repositorios.
        services.AddDbContext<TaskTrackContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<ITaskHistoryRepository, TaskHistoryRepository>();

        return services;
    }
}

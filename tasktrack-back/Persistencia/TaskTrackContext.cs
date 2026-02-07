using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    // Creamos el contexto, esta es una representación de la conexión a la base de datos.
    public class TaskTrackContext : DbContext
    {
        // Constructor de hereda o recibe la propiedad options, que tmb es solicitada por el constructor del Padre
        public TaskTrackContext(DbContextOptions options) : base(options) {
        }

        // OnModelCreating es un método sobrescrito que viene desde el padre
        // protected override void OnModelCreating(ModelBuilder modelBuilder){
        //     base.OnModelCreating(modelBuilder);
        //     // Con esto definimos que CursoInstructor tiene una primaryKey compuesta por el id de instructor y curso
        //     modelBuilder.Entity<CursoInstructor>().HasKey(ci => new {ci.InstructorId, ci.CursoId});
        // }

        // Las clases que creamos en el proyecto dominio las pasamos a Entidades
        // esto envolviendolos en un DbSet
        public DbSet<Tags> Tags {get;set;}
        // public DbSet<TagsTask> TagsTask {get;set;}
        public DbSet<TaskHistory> TaskHistory{get;set;}
        public DbSet<User> User{get;set;}
        public DbSet<UserPreferences> UserPreferences{get;set;}

    }
}
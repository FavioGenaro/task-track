using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    // Creamos el contexto, esta es una representación de la conexión a la base de datos.
    public class TaskTrackContext : DbContext
    {
        // Constructor de hereda o recibe la propiedad options, que tmb es solicitada por el constructor del Padre
        public TaskTrackContext(DbContextOptions options) : base (options) {
        }

        // OnModelCreating es un método sobrescrito que viene desde el padre
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            // TagsTask tiene una primaryKey compuesta
            // configuramos clave compuesta para la tabla intermedia
            modelBuilder.Entity<TagsTask>()
                .HasKey(ci => new {ci.TagId, ci.TaskId});

            modelBuilder.Entity<TagsTask>()
                // .HasOne<Dominio.Entities.Task>() // TagsTask tiene un Task
                .HasOne(tt => tt.Task)
                .WithMany(t => t.Tags) // Task tiene muchas TagsTask
                .HasForeignKey(tt => tt.TaskId);

            modelBuilder.Entity<TagsTask>()
                // .HasOne<Tags>()
                .HasOne(tt => tt.Tag)
                .WithMany(tag => tag.Tasks)
                .HasForeignKey(tt => tt.TagId);


            modelBuilder.Entity<Dominio.Entities.Task>()
                .HasOne<User>() // Task tiene un User
                .WithMany() // User tiene muchas Tasks
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Tags>()
                .HasOne(t => t.User) // Task tiene un User
                .WithMany(u => u.Tags) // User tiene muchas Tags
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskHistory>()
                .HasOne<Dominio.Entities.Task>()
                .WithMany()
                .HasForeignKey(th => th.TaskId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserPreferences) // User tiene un UserPreferences
                .WithOne(p => p.User) // UserPreferences tiene un User
                .HasForeignKey<UserPreferences>(p => p.UserId);
            
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

        // Las clases que creamos en el proyecto dominio las pasamos a Entidades
        // esto envolviendolos en un DbSet
        public DbSet<Dominio.Entities.Task> Tasks {get;set;}
        public DbSet<Tags> Tags {get;set;}
        public DbSet<TagsTask> TagsTask {get;set;}
        public DbSet<TaskHistory> TaskHistory{get;set;}
        public DbSet<User> User{get;set;}
        public DbSet<UserPreferences> UserPreferences{get;set;}

    }
}
using Persistencia;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TaskTrackContext>(opt => {

    // indicamos el tipo de conexion
    // UseSqlServer viene de EF, este recibe la cadena de conexión a la base de datos
    // esta cadena de conexión esta en un archivo independiente, archivo de configuración appsettings.json
    // desde el builder podemos acceder a esa cadena de conexión
    // builder.Configuration.GetConnectionString("DefaultConnection")
    opt.UseSqlServer("Server=FAVIO;Database=TaskTrack;Integrated Security=True;TrustServerCertificate=True", b => b.MigrationsAssembly("WebApi"));

    // options.UseSqlServer(connection, b => b.MigrationsAssembly("WebApi")).
});


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();

    using(var db = new TaskTrackContext(builder.Services.BuildServiceProvider().GetRequiredService<DbContextOptions<TaskTrackContext>>())){

        var cursos = db.Tags.AsNoTracking(); // devuelve un arreglo IQueryable

        // var cursos = db.Curso.Include( p => p.PrecioPromocion).AsNoTracking();
        foreach(var curso in cursos){
            // Console.WriteLine(curso.Titulo + "-------" + curso.PrecioPromocion.PrecioActual);
            Console.WriteLine(curso.Name);
        }
    }    

    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

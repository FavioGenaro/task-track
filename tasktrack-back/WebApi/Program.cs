using Persistencia;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// configuración de serivicios, esta sección se encarga de registrar los servicios que se van a utilizar en la aplicación.
// configuramos NewtonsoftJson
builder.Services.AddControllers().AddNewtonsoftJson();

// AddAplication es un método de extensión que se encarga de registrar 
// las dependencias de la capa de aplicación, este método se encuentra en la clase DependencyInjection 
// de la capa de aplicación,
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Middlewares
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); // este es un middleware

app.Run();

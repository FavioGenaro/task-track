using Persistencia;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

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

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
// agregamos swagger como servicio
builder.Services.AddSwaggerGen(opciones =>
    {
        // personalizamos las opciones de swagger
        opciones.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "TaskTrack API",
            Description = "Este es un web api para trabajar con datos de tus tareas, puedes crear, eliminar, actualizar y consultar.",
            Contact = new OpenApiContact
            {
                Email = "favio@gmail.com",
                Name = "Favio Saico",
                Url = new Uri("https://faviogenaro.github.io/")
            },
            License = new OpenApiLicense // licencia del proyecto
            {
                Name = "MIT",
                Url = new Uri("https://opensource.org/license/mit/")
            }
        });

        // configuramos la interfaz de swagger para que permita el envio de JWTs
        opciones.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            // Type = SecuritySchemeType.ApiKey,
            Type = SecuritySchemeType.Http,
            // Scheme = "Bearer",
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header, // se colocará en la cabecera
            Description = "Ingresa el token JWT así: Bearer {tu_token}"
        });

        // para que swagger sepa que debe enviar el token JWT en las solicitudes, 
        // esto se hace agregando un requisito de seguridad a la documentación de swagger, 
        // este requisito de seguridad indica que se debe enviar un token JWT en la cabecera de las solicitudes.
        opciones.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
    }
);


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

// app.MapSwagger().RequireAuthorization();

// app.UseHttpsRedirection();

app.MapControllers(); // este es un middleware

app.Run();

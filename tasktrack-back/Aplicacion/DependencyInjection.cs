using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MediatR;
using AutoMapper;
public static class DependencyInjection
{
    // AddAplication es un método de extensión que se encarga de registrar las dependencias de la capa de aplicación,
    // este método recibe como parámetros el contenedor de servicios,
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // registra los servicios de MediatR, este método recibe como parámetros 
        // una configuración, esta configuración es una expresión lambda que registra 
        // los servicios de MediatR a partir del ensamblado donde se encuentra 
        // la clase DependencyInjection, esto permite que se registren todos los handlers 
        // de MediatR que se encuentran en ese ensamblado.
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(
                typeof(DependencyInjection).Assembly));

        // AutoMapper, este método recibe como parámetros el ensamblado donde se 
        // encuentra la clase DependencyInjection, permite registrar todos los perfiles de AutoMapper 
        // que se encuentran en ese ensamblado.
        services.AddAutoMapper(
            typeof(DependencyInjection).Assembly);

        // agregamos el servicio para generar tokens
        services.AddScoped<IJwtTokenService, JwtTokenService>();

        // builder.Services.AddHttpContextAccessor(); // accedemos al contexto HTTP desde cualquier clase
        services.AddHttpContextAccessor(); // accedemos al contexto HTTP desde cualquier clase


        var jwtSettings = configuration.GetSection("Jwt");

        services.AddAuthentication(options =>
        {
            // configuramos el esquema de autenticación, en este caso se utiliza JWT Bearer, 
            // esto permite que la aplicación pueda validar los tokens JWT que se envían en las solicitudes.
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {  
            options.MapInboundClaims = false;

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,  // no validamos el origen del token
                ValidateAudience = false,
                ValidateLifetime = false, // que no halla expirado
                ValidateIssuerSigningKey = false, // que valide la llave secreta de la firma

                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],

                 // firmamos el token con la lLave
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings["Key"]!)),
                    
                // ClockSkew = TimeSpan.Zero // para no tener problemas con las diferencias temporales al validar los tokens (UTC-0)
            };
            
        });

        services.AddAuthorization();

        return services;
    }
}

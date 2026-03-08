using Microsoft.Extensions.DependencyInjection;
using MediatR;
using AutoMapper;
public static class DependencyInjection
{
    // AddAplication es un método de extensión que se encarga de registrar las dependencias de la capa de aplicación,
    // este método recibe como parámetros el contenedor de servicios,
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
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

        return services;
    }
}

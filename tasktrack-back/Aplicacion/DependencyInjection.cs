using Microsoft.Extensions.DependencyInjection;
using MediatR;
using AutoMapper;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(
                typeof(DependencyInjection).Assembly));

        // AutoMapper
        services.AddAutoMapper(
            typeof(DependencyInjection).Assembly);

        return services;
    }
}

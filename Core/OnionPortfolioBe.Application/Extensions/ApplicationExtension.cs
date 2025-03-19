using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionPortfolioBe.Application.Interfaces.IServices.AboutService;
using OnionPortfolioBe.Application.Validations;
using System.Reflection;


namespace OnionPortfolioBe.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddScoped<IWriteAboutService, WriteAboutManager>();
        services.AddScoped<IReadAboutService, ReadAboutManager>();

        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly()); // Application katmanındaki tüm IRegister sınıflarını bulur.

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}

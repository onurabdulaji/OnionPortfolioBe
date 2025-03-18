﻿using Microsoft.Extensions.DependencyInjection;
using OnionPortfolioBe.Application.Interfaces.IServices.AboutService;
using System.Reflection;


namespace OnionPortfolioBe.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddScoped<IWriteAboutService, WriteAboutManager>();
        services.AddScoped<IReadAboutService, ReadAboutManager>();

        return services;
    }
}

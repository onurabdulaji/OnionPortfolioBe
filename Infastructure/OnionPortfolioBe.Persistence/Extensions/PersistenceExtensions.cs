using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionPortfolioBe.Application.Interfaces.IUnitOfWorks;
using OnionPortfolioBe.Domain.Interfaces.IRepositories;
using OnionPortfolioBe.Domain.Interfaces.IRepositories.IRepos.AboutIRepo;
using OnionPortfolioBe.Persistence.Context;
using OnionPortfolioBe.Persistence.Repositories;
using OnionPortfolioBe.Persistence.Repositories.Repos.AboutRepo;

namespace OnionPortfolioBe.Persistence.Extensions;

public static class PersistenceExtensions
{
    public static void AddPersistenceLayer(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Spesifik Repository'ler

        services.AddScoped<IAboutReadRepository, AboutReadRepository>();
        services.AddScoped<IAboutWriteRepository, AboutWriteRepository>();

    }
}

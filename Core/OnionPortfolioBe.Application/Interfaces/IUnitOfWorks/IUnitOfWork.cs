using OnionPortfolioBe.Domain.Interfaces.Base;
using OnionPortfolioBe.Domain.Interfaces.IRepositories;
using OnionPortfolioBe.Domain.Interfaces.IRepositories.IRepos.AboutIRepo;

namespace OnionPortfolioBe.Application.Interfaces.IUnitOfWorks;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    IReadRepository<T> GetReadRepository<T>() where T : class, IEntity;
    IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntity;
    Task<int> SaveAsync();
    IAboutReadRepository AboutReadRepository { get; }
    IAboutWriteRepository AboutWriteRepository { get; }
}

using OnionPortfolioBe.Application.Interfaces.IUnitOfWorks;
using OnionPortfolioBe.Domain.Interfaces.IRepositories;
using OnionPortfolioBe.Domain.Interfaces.IRepositories.IRepos.AboutIRepo;
using OnionPortfolioBe.Persistence.Context;
using OnionPortfolioBe.Persistence.Repositories.Repos.AboutRepo;

namespace OnionPortfolioBe.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public IAboutReadRepository AboutReadRepository
    {
        get
        {
            if (!_repositories.ContainsKey(typeof(IAboutReadRepository)))
            {
                _repositories[typeof(IAboutReadRepository)] = new AboutReadRepository(_context);
            }
            return (IAboutReadRepository)_repositories[typeof(IAboutReadRepository)];
        }
    }
    public IAboutWriteRepository AboutWriteRepository
    {
        get
        {
            if (!_repositories.ContainsKey(typeof(IAboutWriteRepository)))
            {
                _repositories[typeof(IAboutWriteRepository)] = new AboutWriteRepository(_context);
            }
            return (IAboutWriteRepository)_repositories[typeof(IAboutWriteRepository)];
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _context.DisposeAsync();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    IReadRepository<T> IUnitOfWork.GetReadRepository<T>()
    {
        if (!_repositories.ContainsKey(typeof(IReadRepository<T>)))
        {
            _repositories[typeof(IReadRepository<T>)] = new ReadRepository<T>(_context);
        }
        return (IReadRepository<T>)_repositories[typeof(IReadRepository<T>)];
    }

    IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()
    {
        if (!_repositories.ContainsKey(typeof(IWriteRepository<T>)))
        {
            _repositories[typeof(IWriteRepository<T>)] = new WriteRepository<T>(_context);
        }
        return (IWriteRepository<T>)_repositories[typeof(IWriteRepository<T>)];
    }
}

using Microsoft.EntityFrameworkCore;
using OnionPortfolioBe.Domain.Interfaces.Base;
using OnionPortfolioBe.Domain.Interfaces.IRepositories;
using OnionPortfolioBe.Persistence.Context;

namespace OnionPortfolioBe.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntity
{
    protected readonly AppDbContext _context;

    public WriteRepository(AppDbContext context)
    {
        _context = context;
    }
    private DbSet<T> Table { get => _context.Set<T>(); }

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public async Task<(bool isSuccess, T entity)> ChangeStatusAsync(T entity)
    {
        entity.IsActive = !entity.IsActive;
        Table.Update(entity);
        var result = await _context.SaveChangesAsync();
        return (result > 0, entity);
    }

    public async Task<T> RemoveAsync(T entity)
    {
        await Task.Run(() => Table.Remove(entity));
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        await Task.Run(() => Table.Update(entity));
        return entity;
    }
}

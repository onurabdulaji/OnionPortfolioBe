using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OnionPortfolioBe.Domain.Interfaces.Base;
using OnionPortfolioBe.Domain.Interfaces.IRepositories;
using OnionPortfolioBe.Persistence.Context;
using System.Linq.Expressions;

namespace OnionPortfolioBe.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : class, IEntity
{
    protected readonly AppDbContext _context;

    public ReadRepository(AppDbContext context)
    {
        _context = context;
    }
    private DbSet<T> Table { get => _context.Set<T>(); }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        Table.AsNoTracking();
        if (predicate is not null) Table.Where(predicate);

        return await Table.CountAsync();
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
    {
        if (!enableTracking) Table.AsNoTracking();
        return Table.Where(predicate);
    }

    public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
    {
        IQueryable<T> queryable = Table;
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);
        if (predicate is not null) queryable = queryable.Where(predicate);
        if (orderBy is not null)
            return await orderBy(queryable).ToListAsync();

        return await queryable.ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
    {
        IQueryable<T> queryable = Table;
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);

        //queryable.Where(predicate);

        return await queryable.FirstOrDefaultAsync(predicate);
    }
}

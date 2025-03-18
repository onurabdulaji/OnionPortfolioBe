using Microsoft.EntityFrameworkCore;
using OnionPortfolioBe.Domain.Entities;
using OnionPortfolioBe.Domain.Interfaces.IRepositories.IRepos.AboutIRepo;
using OnionPortfolioBe.Persistence.Context;

namespace OnionPortfolioBe.Persistence.Repositories.Repos.AboutRepo;

public class AboutReadRepository : ReadRepository<About>, IAboutReadRepository
{
    public AboutReadRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IList<About>> GetAllAsync()
    {
        return await _context.Abouts.ToListAsync();
    }

    public async Task<About> GetByIdAsync(Guid id)
    {
        return await _context.Abouts.FindAsync(id);
    }
}

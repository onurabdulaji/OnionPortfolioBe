using Microsoft.EntityFrameworkCore;
using OnionPortfolioBe.Domain.Entities;
using OnionPortfolioBe.Domain.Interfaces.IRepositories.IRepos.AboutIRepo;
using OnionPortfolioBe.Persistence.Context;

namespace OnionPortfolioBe.Persistence.Repositories.Repos.AboutRepo;

public class AboutWriteRepository : WriteRepository<About>, IAboutWriteRepository
{
    public AboutWriteRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<About> CreateAsync(About about, CancellationToken cancellationToken)
    {
        await _context.Abouts.AddAsync(about, cancellationToken);
        return about;
    }

    public async Task<About> DeleteAsync(About about, CancellationToken cancellationToken)
    {
        _context.Abouts.Remove(about);
        await _context.SaveChangesAsync(cancellationToken);
        return about;
    }

    public async Task<bool> UpdateAsync(About about, CancellationToken cancellationToken)
    {
        var existing = await _context.Abouts.FindAsync(about.Id);
        if (existing == null)
        {
            return false;
        }
        _context.Entry(existing).CurrentValues.SetValues(about);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
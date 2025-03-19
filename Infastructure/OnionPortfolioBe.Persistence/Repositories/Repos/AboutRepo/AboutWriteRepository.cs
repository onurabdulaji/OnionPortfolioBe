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
        await _context.SaveChangesAsync(cancellationToken);
        return about;
    }
}
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Domain.Interfaces.IRepositories.IRepos.AboutIRepo;

public interface IAboutWriteRepository : IWriteRepository<About>
{
    Task<About> CreateAsync(About about, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(About about, CancellationToken cancellationToken);
    Task<About> DeleteAsync(About about, CancellationToken cancellationToken);
}

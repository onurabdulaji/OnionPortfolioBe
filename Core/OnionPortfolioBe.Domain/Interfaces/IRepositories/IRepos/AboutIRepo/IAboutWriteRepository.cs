using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Domain.Interfaces.IRepositories.IRepos.AboutIRepo;

public interface IAboutWriteRepository :  IWriteRepository<About>
{
    Task<About> CreateAsync(About about, CancellationToken cancellationToken);
}

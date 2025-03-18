using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Domain.Interfaces.IRepositories.IRepos.AboutIRepo;

public interface IAboutReadRepository : IReadRepository<About>
{
    Task<About> GetByIdAsync(Guid id);
    Task<IList<About>> GetAllAsync();
}

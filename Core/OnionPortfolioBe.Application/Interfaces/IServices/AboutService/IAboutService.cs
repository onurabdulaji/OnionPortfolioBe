using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Application.Interfaces.IServices.AboutService;

public interface IAboutService
{
    Task<About> GetByIdAsync(Guid id);
    Task<IList<GetAllAboutQueryResponse>> GetAllAsync();
    //Task<About> CreateAsync(About about);
    //Task<About> UpdateAsync(About about);
    //Task<About> RemoveAsync(Guid id);
}

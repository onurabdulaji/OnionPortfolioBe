using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Application.Interfaces.IServices.AboutService;

public interface IReadAboutService
{
    Task<IList<GetAllAboutQueryResponse>> GetAllAboutAsync(CancellationToken cancellationToken);
    Task<About> GetAboutByIdAsync(Guid id); // Todo Remove Paramater from Task make that with DTO

}

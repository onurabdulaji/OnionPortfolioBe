using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries.GetAboutById;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Application.Interfaces.IServices.AboutService;

public interface IReadAboutService
{
    Task<IList<GetAllAboutQueryResponse>> GetAllAboutAsync(CancellationToken cancellationToken);
    Task<GetAboutByIdResponse> GetAboutByIdAsync(Guid Id, CancellationToken cancellationToken);
}

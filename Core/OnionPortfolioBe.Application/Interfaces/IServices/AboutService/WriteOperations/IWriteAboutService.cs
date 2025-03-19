using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.CreateAbout;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.RemoveAbout;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.UpdateAbout;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Application.Interfaces.IServices.AboutService;

public interface IWriteAboutService
{
    Task<CreateAboutResponse> CreateAsync(CreateAboutRequest request, CancellationToken cancellationToken);
    Task<UpdateAboutResponse> UpdateAsync(UpdateAboutRequest request, CancellationToken cancellationToken);
    Task<RemoveAboutResponse> DeleteAsync(RemoveAboutRequest request, CancellationToken cancellationToken);
}

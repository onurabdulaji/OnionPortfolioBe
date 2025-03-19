using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using OnionPortfolioBe.Application.Interfaces.IServices.AboutService;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries.GetAboutById;

public class GetAboutByIdHandler : IRequestHandler<GetAboutByIdRequest, GetAboutByIdResponse>
{
    private readonly IReadAboutService _readAboutService;
    private readonly ILogger<GetAboutByIdHandler> _logger;

    public GetAboutByIdHandler(IReadAboutService readAboutService, ILogger<GetAboutByIdHandler> logger)
    {
        _readAboutService = readAboutService;
        _logger = logger;
    }

    public async Task<GetAboutByIdResponse> Handle(GetAboutByIdRequest request, CancellationToken cancellationToken)
    {
        var aboutById = await _readAboutService.GetAboutByIdAsync(request.Id, cancellationToken);
        return aboutById.Adapt<GetAboutByIdResponse>();
    }
}

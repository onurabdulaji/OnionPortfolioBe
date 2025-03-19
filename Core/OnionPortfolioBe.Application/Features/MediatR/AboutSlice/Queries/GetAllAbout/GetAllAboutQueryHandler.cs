using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using OnionPortfolioBe.Application.Interfaces.IServices.AboutService;

namespace OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;

public class GetAllAboutQueryHandler : IRequestHandler<GetAllAboutQueryRequest, IList<GetAllAboutQueryResponse>>
{
    private readonly IReadAboutService _readAboutService;
    private readonly ILogger<GetAllAboutQueryHandler> _logger;

    public GetAllAboutQueryHandler(IReadAboutService readAboutService, ILogger<GetAllAboutQueryHandler> logger)
    {
        _readAboutService = readAboutService;
        _logger = logger;
    }

    public async Task<IList<GetAllAboutQueryResponse>> Handle(GetAllAboutQueryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handler başlatıldı ve {request} ile başladı.", request);

        if(cancellationToken.IsCancellationRequested)
        {
            _logger.LogWarning("Handler iptal edildi ve {request} ile iptal edildi.", request);
            return new List<GetAllAboutQueryResponse>();
        }

        var aboutsLists = await _readAboutService.GetAllAboutAsync(cancellationToken);
        _logger.LogTrace("aboutsLists alındı: {aboutsLists}", aboutsLists);

        if (aboutsLists is null || aboutsLists.Count == 0)
        {
            _logger.LogWarning("No Abouts Found");
            return new List<GetAllAboutQueryResponse>();
        }

        var response = aboutsLists.Adapt<IList<GetAllAboutQueryResponse>>();
        _logger.LogInformation("Handler başarıyla tamamlandı ve {count} kayıt döndürüldü.", response.Count);
        return response;
    }
}


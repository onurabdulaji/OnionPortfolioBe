using MediatR;
using Microsoft.Extensions.Logging;
using OnionPortfolioBe.Application.Interfaces.IServices.AboutService;

namespace OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.CreateAbout;

public class CreateAboutHandler : IRequestHandler<CreateAboutRequest, CreateAboutResponse>
{
    private readonly IWriteAboutService _writeAboutService;
    private readonly ILogger<CreateAboutHandler> _logger;

    public CreateAboutHandler(IWriteAboutService writeAboutService, ILogger<CreateAboutHandler> logger)
    {
        _writeAboutService = writeAboutService;
        _logger = logger;
    }
    public async Task<CreateAboutResponse> Handle(CreateAboutRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CreateAboutCommand işleniyor: {request}", request);

        var createdAbout = await _writeAboutService.CreateAsync(request, cancellationToken);

        _logger.LogInformation("Yeni About kaydı oluşturuldu: {Id}", createdAbout.Id);

        return new CreateAboutResponse
        {
            Id = createdAbout.Id,
            Message = "About başarıyla oluşturuldu."
        };
    }
}

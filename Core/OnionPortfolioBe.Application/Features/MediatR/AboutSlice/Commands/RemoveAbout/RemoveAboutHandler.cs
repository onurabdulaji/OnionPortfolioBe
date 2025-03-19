using MediatR;
using OnionPortfolioBe.Application.Interfaces.IServices.AboutService;

namespace OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.RemoveAbout;

public class RemoveAboutHandler : IRequestHandler<RemoveAboutRequest, RemoveAboutResponse>
{
    private readonly IWriteAboutService _writeAboutService;

    public RemoveAboutHandler(IWriteAboutService writeAboutService)
    {
        _writeAboutService = writeAboutService;
    }

    public async Task<RemoveAboutResponse> Handle(RemoveAboutRequest request, CancellationToken cancellationToken)
    {
        var response = await _writeAboutService.DeleteAsync(request,cancellationToken);
        return response;
    }
}

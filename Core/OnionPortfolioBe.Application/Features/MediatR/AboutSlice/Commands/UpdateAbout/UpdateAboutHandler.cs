using Mapster;
using MediatR;
using OnionPortfolioBe.Application.Interfaces.IServices.AboutService;

namespace OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.UpdateAbout;

public class UpdateAboutHandler : IRequestHandler<UpdateAboutRequest, UpdateAboutResponse>
{
    private readonly IWriteAboutService _writeAboutService;

    public UpdateAboutHandler(IWriteAboutService writeAboutService)
    {
        _writeAboutService = writeAboutService;
    }

    public async Task<UpdateAboutResponse> Handle(UpdateAboutRequest request, CancellationToken cancellationToken)
    {
        var updatedAbout = await _writeAboutService.UpdateAsync(request, cancellationToken);
        var response=  updatedAbout.Adapt<UpdateAboutResponse>();
        return response;
    }
}

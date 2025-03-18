using MediatR;
using OnionPortfolioBe.Application.Interfaces.IServices.AboutService;

namespace OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;

public class GetAllAboutQueryHandler : IRequestHandler<GetAllAboutQueryRequest, IList<GetAllAboutQueryResponse>>
{
    private readonly IReadAboutService _readAboutService;

    public GetAllAboutQueryHandler(IReadAboutService readAboutService)
    {
        _readAboutService = readAboutService;
    }

    public async Task<IList<GetAllAboutQueryResponse>> Handle(GetAllAboutQueryRequest request, CancellationToken cancellationToken)
    {
        var aboutsLists = await _readAboutService.GetAllAboutAsync();
        return aboutsLists;
    }
}

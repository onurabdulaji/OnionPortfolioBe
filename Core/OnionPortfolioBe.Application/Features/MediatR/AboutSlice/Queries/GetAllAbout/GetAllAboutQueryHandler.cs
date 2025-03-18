using MediatR;
using OnionPortfolioBe.Application.Interfaces.IServices.AboutService;

namespace OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;

public class GetAllAboutQueryHandler : IRequestHandler<GetAllAboutQueryRequest, IList<GetAllAboutQueryResponse>>
{
    private readonly IAboutService _aboutService;

    public GetAllAboutQueryHandler(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    public async Task<IList<GetAllAboutQueryResponse>> Handle(GetAllAboutQueryRequest request, CancellationToken cancellationToken)
    {
        var aboutsLists = await _aboutService.GetAllAsync();
        return aboutsLists;
    }
}

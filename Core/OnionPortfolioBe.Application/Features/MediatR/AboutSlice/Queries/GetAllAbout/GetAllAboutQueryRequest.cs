using MediatR;

namespace OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;

public class GetAllAboutQueryRequest : IRequest<IList<GetAllAboutQueryResponse>>
{
}

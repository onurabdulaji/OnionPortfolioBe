using MediatR;

namespace OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.RemoveAbout;

public class RemoveAboutRequest : IRequest<RemoveAboutResponse>
{
    public  Guid Id { get; set; }
    public RemoveAboutRequest(Guid id)
    {
        Id = id;
    }
}

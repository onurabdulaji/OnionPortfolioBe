using OnionPortfolioBe.Application.Mapping.Mapster;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.RemoveAbout;

public class RemoveAboutResponse : BaseDto<RemoveAboutResponse,About>
{
    public Guid Id { get; set; }
    public string Message { get; set; }
}

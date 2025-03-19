using OnionPortfolioBe.Application.Mapping.Mapster;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.CreateAbout;

public class CreateAboutResponse : BaseDto<CreateAboutResponse,About>
{
    public Guid Id { get; set; }
    public string? Message { get; set; }
}

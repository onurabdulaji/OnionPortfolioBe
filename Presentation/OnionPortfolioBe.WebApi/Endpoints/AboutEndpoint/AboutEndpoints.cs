using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.CreateAbout;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;

namespace OnionPortfolioBe.WebApi.Endpoints.AboutEndpoint;

public class AboutEndpoints
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapGet("/api/Abouts/GetAll", async (ISender sender) =>
        {
            var response = await sender.Send(new GetAllAboutQueryRequest());
            return Results.Ok(response);
        });

        app.MapPost("/api/Abouts/Create", async (ISender sender, [FromBody] CreateAboutRequest request) =>
        {
            var response = await sender.Send(request);
            return Results.Ok(response);
        });
    }

}



/// <summary>
/// Tut aklina ki ne zaman dondurursun bir veri buni parametre olarak eklemesin.
/// Fakat ne zaman eklersin ve guncellersin o zaman parametre olarak eklersin.
/// Ve bu yapi daha da Moduler olabirler eger Carter kullanirsek.
/// </summary>
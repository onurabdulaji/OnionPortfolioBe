using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.CreateAbout;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.RemoveAbout;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.UpdateAbout;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries.GetAboutById;

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

        app.MapGet("/api/Abouts/GetAboutByID/{id}", async (Guid Id, ISender sender) =>
        {
            var request = new GetAboutByIdRequest(Id);
            var response = await sender.Send(request);
            return Results.Ok(response);
        });

        app.MapPut("/api/Abouts/Update", async (UpdateAboutRequest updatedAbout, ISender sender) =>
        {
            var response = await sender.Send(updatedAbout);
            return Results.Ok(response);
        });

        app.MapPost("/api/Abouts/Create", async (ISender sender, [FromBody] CreateAboutRequest request) =>
        {
            var response = await sender.Send(request);
            return Results.Ok(response);
        });

        app.MapDelete("/api/Abouts/{id}", async (Guid Id, ISender sender, CancellationToken cancellationToken) =>
        {
            var request = new RemoveAboutRequest(Id);
            var response = await sender.Send(request,cancellationToken);
            return Results.Ok(response);
        });
    }

}



/// <summary>
/// Tut aklina ki ne zaman dondurursun bir veri buni parametre olarak eklemesin.
/// Fakat ne zaman eklersin ve guncellersin o zaman parametre olarak eklersin.
/// Ve bu yapi daha da Moduler olabirler eger Carter kullanirsek.
/// 
/// 
/// Post Ve Put islemleri olurken Id gondermesik ama Servis put icin lazim bulunsun ID.
/// 
/// Delete ve Get icin => delete icin gerekecek id , ama get icin sadece by id de gerekecek id.
/// 
/// </summary>
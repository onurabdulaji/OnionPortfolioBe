using Mapster;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries.GetAboutById;
using OnionPortfolioBe.Application.Interfaces.IUnitOfWorks;
using OnionPortfolioBe.Domain.Entities;
using OnionPortfolioBe.Domain.Interfaces.IRepositories.IRepos.AboutIRepo;
using System;

namespace OnionPortfolioBe.Application.Interfaces.IServices.AboutService;

public class ReadAboutManager : IReadAboutService
{
    private readonly IUnitOfWork _unitOfWork;

    public ReadAboutManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetAboutByIdResponse> GetAboutByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        var about = await _unitOfWork.AboutReadRepository.GetByIdAsync(Id);
        if(about is null)
        {
            throw new Exception("About not found");
        }

        return about.Adapt<GetAboutByIdResponse>();
    }

    public async Task<IList<GetAllAboutQueryResponse>> GetAllAboutAsync(CancellationToken cancellationToken)
    {
        var aboutsList = await _unitOfWork.AboutReadRepository.GetAllAsync();
        return aboutsList.Select(a => new GetAllAboutQueryResponse
        {
            Id = a.Id,
            Title = a.Title,
            Description = a.Description,
            Birthday = a.Birthday,
            Age = a.Age,
            Website = a.Website,
            Degree = a.Degree,
            Phone = a.Phone,
            Email = a.Email,
            City = a.City,
            IsFreelanceAvailable = a.IsFreelanceAvailable
        }).ToList();
    }
}

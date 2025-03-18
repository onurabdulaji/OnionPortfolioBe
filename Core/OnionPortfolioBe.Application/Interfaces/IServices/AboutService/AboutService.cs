using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;
using OnionPortfolioBe.Application.Interfaces.IUnitOfWorks;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Application.Interfaces.IServices.AboutService;

public class AboutService : IAboutService
{
    private readonly IUnitOfWork _unitOfWork;

    public AboutService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IList<GetAllAboutQueryResponse>> GetAllAsync()
    {
        var aboutsList = await _unitOfWork.AboutReadRepository.GetAllAsync();
        return aboutsList.Select ( a=> new GetAllAboutQueryResponse
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

    public Task<About> GetByIdAsync(Guid id)
    {
        var getAboutByIdResult = _unitOfWork.AboutReadRepository;
        return getAboutByIdResult.GetByIdAsync(id);
    }
}

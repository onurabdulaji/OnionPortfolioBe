using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;
using OnionPortfolioBe.Application.Interfaces.IUnitOfWorks;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Application.Interfaces.IServices.AboutService;

public class WriteAboutManager : IWriteAboutService
{
    private readonly IUnitOfWork _unitOfWork;

    public WriteAboutManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}

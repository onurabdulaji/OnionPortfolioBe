using FluentValidation;
using Mapster;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.CreateAbout;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;
using OnionPortfolioBe.Application.Interfaces.IUnitOfWorks;
using OnionPortfolioBe.Application.Validations.About;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Application.Interfaces.IServices.AboutService;

public class WriteAboutManager : IWriteAboutService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateAboutRequest> _validator;

    public WriteAboutManager(IUnitOfWork unitOfWork, IValidator<CreateAboutRequest> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<About> CreateAsync(CreateAboutRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var about = request.Adapt<About>();

        var createdAbout = await _unitOfWork.AboutWriteRepository.CreateAsync(about, cancellationToken);

        return createdAbout;
    }
}
using FluentValidation;
using Mapster;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.CreateAbout;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.RemoveAbout;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.UpdateAbout;
using OnionPortfolioBe.Application.Interfaces.IUnitOfWorks;
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

    public async Task<CreateAboutResponse> CreateAsync(CreateAboutRequest request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var about = request.Adapt<About>();

        var createdAbout = await _unitOfWork.AboutWriteRepository.CreateAsync(about, cancellationToken);

        await _unitOfWork.SaveAsync();

        return createdAbout.Adapt<CreateAboutResponse>();
    }

    public async Task<RemoveAboutResponse> DeleteAsync(RemoveAboutRequest request, CancellationToken cancellationToken)
    {
        var exist = await _unitOfWork.AboutReadRepository.GetByIdAsync(request.Id);
        if (exist is null)
        {
            return new RemoveAboutResponse
            {
                Id = request.Id,
                Message = "About Verisi Bulunamadi"
            };
        }
        await _unitOfWork.AboutWriteRepository.DeleteAsync(exist, cancellationToken);
        await _unitOfWork.SaveAsync();

        return new RemoveAboutResponse { Id = request.Id, Message = "About Basariyla Silindi" };
    }

    public async Task<UpdateAboutResponse> UpdateAsync(UpdateAboutRequest request, CancellationToken cancellationToken)
    {
        // Mevcut veriyi getir
        var existingAbout = await _unitOfWork.AboutReadRepository.GetByIdAsync(request.Id);
        if (existingAbout is null)
        {
            // Hata durumu: Veritabanında bulunamadı
            throw new Exception("About verisi bulunamadı");
        }

        // Güncellemeyi Mapster ile yap
        request.Adapt(existingAbout);

        // Güncellemeyi gerçekleştir
        var updated = await _unitOfWork.AboutWriteRepository.UpdateAsync(existingAbout, cancellationToken);

        if (!updated)
        {
            // Hata durumu: Güncelleme işlemi başarısız
            throw new Exception("Güncelleme başarısız!");
        }

        // Güncellenen veriyi response olarak döndür
        return existingAbout.Adapt<UpdateAboutResponse>();
    }
}

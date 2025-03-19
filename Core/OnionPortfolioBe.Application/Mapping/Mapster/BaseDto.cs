using Mapster;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.CreateAbout;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Application.Mapping.Mapster
{
    public abstract class BaseDto<TDto, TEntity> : IRegister where TDto : class, new() where TEntity : class, new()
    {
        public virtual void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TDto, TEntity>()
                .TwoWays();
        }
    }
}

// Tum Dto lar otomatik olarak by donusum mekanizmasini kullanur.
// Bu sınıf, her DTO için iki yönlü dönüşüm (DTO → Entity, Entity → DTO) sağlar ve IRegister ile otomatik olarak Mapster konfigürasyonuna eklenir.

//Ornek bir yaklasim , ozel bir response icin  
//public class CreateAboutToCreateAboutResponseMapping : IRegister
//{
//    public void Register(TypeAdapterConfig config)
//    {
//        config.NewConfig<About, CreateAboutResponse>()
//            .Map(dest => dest.Message, src => "About başarıyla oluşturuldu.")
//            .TwoWays();  // Bu satır tüm diğer özellikler için iki yönlü eşleme yapar.
//    }
//}
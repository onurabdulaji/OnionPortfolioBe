using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Persistence.Configurations;

public class SocialMediaConfiguration : BaseConfiguration<SocialMedia>
{
    public override void Configure(EntityTypeBuilder<SocialMedia> builder)
    {
        base.Configure(builder);
        builder.HasKey(x => x.Id);
    }
}

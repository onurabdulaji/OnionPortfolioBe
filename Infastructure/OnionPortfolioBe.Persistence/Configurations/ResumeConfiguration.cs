using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Persistence.Configurations;

public class ResumeConfiguration : BaseConfiguration<Resume>
{
    public override void Configure(EntityTypeBuilder<Resume> builder)
    {
        base.Configure(builder);
        builder.HasKey(x => x.Id);
    }
}

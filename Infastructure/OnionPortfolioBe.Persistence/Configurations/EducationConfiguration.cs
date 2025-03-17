using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Persistence.Configurations;

public class EducationConfiguration : BaseConfiguration<Education>
{
    public override void Configure(EntityTypeBuilder<Education> builder)
    {
        base.Configure(builder);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FromYear)
            .IsRequired();

        builder.Property(x => x.ToYear)
           .IsRequired();

        builder.Property(x => x.Degree)
           .IsRequired();

        builder.Property(x => x.Description)
           .IsRequired();
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionPortfolioBe.Domain.Entities;

namespace OnionPortfolioBe.Persistence.Configurations;

public class SkillConfiguration : BaseConfiguration<Skill>
{
    public override void Configure(EntityTypeBuilder<Skill> builder)
    {
        base.Configure(builder);
        builder.HasKey(x => x.Id);
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DefinitionHeroClassConfiguration : IEntityTypeConfiguration<DefinitionHeroClass>
{
    public void Configure(EntityTypeBuilder<DefinitionHeroClass> builder)
    {
        builder.ToTable("DefinitionHeroClasses").HasKey(dhc => dhc.Id);

        builder.Property(dhc => dhc.Id).HasColumnName("Id").IsRequired();
        builder.Property(dhc => dhc.Value).HasColumnName("Value");
        builder.Property(dhc => dhc.HealthPoints).HasColumnName("HealthPoints").IsRequired();
        builder.Property(dhc => dhc.AttackPoints).HasColumnName("AttackPoints").IsRequired();
        builder.Property(dhc => dhc.DefencePoints).HasColumnName("DefencePoints").IsRequired();
        builder.Property(dhc => dhc.AttackSpeedMultiplier).HasColumnName("AttackSpeedMultiplier").IsRequired();
        builder.Property(dhc => dhc.DefaultPetId).HasColumnName("DefaultPetId");
        builder.Property(dhc => dhc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(dhc => dhc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(dhc => dhc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(dhc => !dhc.DeletedDate.HasValue);
    }
}
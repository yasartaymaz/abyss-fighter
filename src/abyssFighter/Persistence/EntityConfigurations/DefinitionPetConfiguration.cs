using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DefinitionPetConfiguration : IEntityTypeConfiguration<DefinitionPet>
{
    public void Configure(EntityTypeBuilder<DefinitionPet> builder)
    {
        builder.ToTable("DefinitionPets").HasKey(dp => dp.Id);

        builder.Property(dp => dp.Id).HasColumnName("Id").IsRequired();
        builder.Property(dp => dp.DefinitionPetTypeId).HasColumnName("DefinitionPetTypeId").IsRequired();
        builder.Property(dp => dp.Name).HasColumnName("Name");
        builder.Property(dp => dp.AttackPoints).HasColumnName("AttackPoints").IsRequired();
        builder.Property(dp => dp.DefencePoints).HasColumnName("DefencePoints").IsRequired();
        builder.Property(dp => dp.HealthPoints).HasColumnName("HealthPoints").IsRequired();
        builder.Property(dp => dp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(dp => dp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(dp => dp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(dp => !dp.DeletedDate.HasValue);
    }
}
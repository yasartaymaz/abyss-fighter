using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DefinitionWeaponTypeConfiguration : IEntityTypeConfiguration<DefinitionWeaponType>
{
    public void Configure(EntityTypeBuilder<DefinitionWeaponType> builder)
    {
        builder.ToTable("DefinitionWeaponTypes").HasKey(dwt => dwt.Id);

        builder.Property(dwt => dwt.Id).HasColumnName("Id").IsRequired();
        builder.Property(dwt => dwt.Value).HasColumnName("Value");
        builder.Property(dwt => dwt.IsOneHanded).HasColumnName("IsOneHanded").IsRequired();
        builder.Property(dwt => dwt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(dwt => dwt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(dwt => dwt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(dwt => !dwt.DeletedDate.HasValue);
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DefinitionWeaponConfiguration : IEntityTypeConfiguration<DefinitionWeapon>
{
    public void Configure(EntityTypeBuilder<DefinitionWeapon> builder)
    {
        builder.ToTable("DefinitionWeapons").HasKey(dw => dw.Id);

        builder.Property(dw => dw.Id).HasColumnName("Id").IsRequired();
        builder.Property(dw => dw.DefinitionWeaponTypeId).HasColumnName("DefinitionWeaponTypeId").IsRequired();
        builder.Property(dw => dw.Name).HasColumnName("Name");
        builder.Property(dw => dw.IsOneHanded).HasColumnName("IsOneHanded").IsRequired();
        builder.Property(dw => dw.AttackPoints).HasColumnName("AttackPoints").IsRequired();
        builder.Property(dw => dw.DefencePoints).HasColumnName("DefencePoints").IsRequired();
        builder.Property(dw => dw.AttackSpeedMultiplier).HasColumnName("AttackSpeedMultiplier").IsRequired();
        builder.Property(dw => dw.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(dw => dw.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(dw => dw.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(dw => !dw.DeletedDate.HasValue);
    }
}
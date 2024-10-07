using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DefinitionItemConfiguration : IEntityTypeConfiguration<DefinitionItem>
{
    public void Configure(EntityTypeBuilder<DefinitionItem> builder)
    {
        builder.ToTable("DefinitionItems").HasKey(di => di.Id);

        builder.Property(di => di.Id).HasColumnName("Id").IsRequired();
        builder.Property(di => di.DefinitionItemTypeId).HasColumnName("DefinitionItemTypeId").IsRequired();
        builder.Property(di => di.ItemId).HasColumnName("ItemId").IsRequired();
        builder.Property(di => di.IsStackable).HasColumnName("IsStackable").IsRequired();
        builder.Property(di => di.IsWeapon).HasColumnName("IsWeapon").IsRequired();
        builder.Property(di => di.IsArmor).HasColumnName("IsArmor").IsRequired();
        builder.Property(di => di.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(di => di.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(di => di.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(di => !di.DeletedDate.HasValue);
    }
}
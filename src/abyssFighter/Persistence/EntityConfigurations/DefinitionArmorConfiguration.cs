using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DefinitionArmorConfiguration : IEntityTypeConfiguration<DefinitionArmor>
{
    public void Configure(EntityTypeBuilder<DefinitionArmor> builder)
    {
        builder.ToTable("DefinitionArmors").HasKey(da => da.Id);

        builder.Property(da => da.Id).HasColumnName("Id").IsRequired();
        builder.Property(da => da.DefinitionArmorTypeId).HasColumnName("DefinitionArmorTypeId").IsRequired();
        builder.Property(da => da.DefinitionArmorPartId).HasColumnName("DefinitionArmorPartId").IsRequired();
        builder.Property(da => da.Name).HasColumnName("Name");
        builder.Property(da => da.DefencePoints).HasColumnName("DefencePoints").IsRequired();
        builder.Property(da => da.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(da => da.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(da => da.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(da => !da.DeletedDate.HasValue);
    }
}
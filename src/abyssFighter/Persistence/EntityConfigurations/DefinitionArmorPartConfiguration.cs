using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DefinitionArmorPartConfiguration : IEntityTypeConfiguration<DefinitionArmorPart>
{
    public void Configure(EntityTypeBuilder<DefinitionArmorPart> builder)
    {
        builder.ToTable("DefinitionArmorParts").HasKey(dap => dap.Id);

        builder.Property(dap => dap.Id).HasColumnName("Id").IsRequired();
        builder.Property(dap => dap.Value).HasColumnName("Value");
        builder.Property(dap => dap.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(dap => dap.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(dap => dap.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(dap => !dap.DeletedDate.HasValue);
    }
}
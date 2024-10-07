using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DefinitionItemTypeConfiguration : IEntityTypeConfiguration<DefinitionItemType>
{
    public void Configure(EntityTypeBuilder<DefinitionItemType> builder)
    {
        builder.ToTable("DefinitionItemTypes").HasKey(dit => dit.Id);

        builder.Property(dit => dit.Id).HasColumnName("Id").IsRequired();
        builder.Property(dit => dit.Value).HasColumnName("Value");
        builder.Property(dit => dit.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(dit => dit.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(dit => dit.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(dit => !dit.DeletedDate.HasValue);
    }
}
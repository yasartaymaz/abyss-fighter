using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DefinitionWalletTypeConfiguration : IEntityTypeConfiguration<DefinitionWalletType>
{
    public void Configure(EntityTypeBuilder<DefinitionWalletType> builder)
    {
        builder.ToTable("DefinitionWalletTypes").HasKey(dwt => dwt.Id);

        builder.Property(dwt => dwt.Id).HasColumnName("Id").IsRequired();
        builder.Property(dwt => dwt.Value).HasColumnName("Value");
        builder.Property(dwt => dwt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(dwt => dwt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(dwt => dwt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(dwt => !dwt.DeletedDate.HasValue);
    }
}
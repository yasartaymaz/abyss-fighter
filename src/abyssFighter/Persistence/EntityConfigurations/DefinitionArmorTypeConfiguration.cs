using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DefinitionArmorTypeConfiguration : IEntityTypeConfiguration<DefinitionArmorType>
{
    public void Configure(EntityTypeBuilder<DefinitionArmorType> builder)
    {
        builder.ToTable("DefinitionArmorTypes").HasKey(dat => dat.Id);

        builder.Property(dat => dat.Id).HasColumnName("Id").IsRequired();
        builder.Property(dat => dat.Value).HasColumnName("Value");
        builder.Property(dat => dat.HeroClassId).HasColumnName("HeroClassId").IsRequired();
        builder.Property(dat => dat.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(dat => dat.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(dat => dat.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(dat => !dat.DeletedDate.HasValue);
    }
}
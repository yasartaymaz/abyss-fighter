using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DefinitionPetTypeConfiguration : IEntityTypeConfiguration<DefinitionPetType>
{
    public void Configure(EntityTypeBuilder<DefinitionPetType> builder)
    {
        builder.ToTable("DefinitionPetTypes").HasKey(dpt => dpt.Id);

        builder.Property(dpt => dpt.Id).HasColumnName("Id").IsRequired();
        builder.Property(dpt => dpt.Value).HasColumnName("Value");
        builder.Property(dpt => dpt.IsAttack).HasColumnName("IsAttack").IsRequired();
        builder.Property(dpt => dpt.IsDefence).HasColumnName("IsDefence").IsRequired();
        builder.Property(dpt => dpt.IsHybrid).HasColumnName("IsHybrid").IsRequired();
        builder.Property(dpt => dpt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(dpt => dpt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(dpt => dpt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(dpt => !dpt.DeletedDate.HasValue);
    }
}
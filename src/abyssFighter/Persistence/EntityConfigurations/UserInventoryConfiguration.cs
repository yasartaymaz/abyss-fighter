using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserInventoryConfiguration : IEntityTypeConfiguration<UserInventory>
{
    public void Configure(EntityTypeBuilder<UserInventory> builder)
    {
        builder.ToTable("UserInventories").HasKey(ui => ui.Id);

        builder.Property(ui => ui.Id).HasColumnName("Id").IsRequired();
        builder.Property(ui => ui.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(ui => ui.UserHeroId).HasColumnName("UserHeroId").IsRequired();
        builder.Property(ui => ui.DefinitionItemId).HasColumnName("DefinitionItemId").IsRequired();
        builder.Property(ui => ui.DefinitionItemTypeId).HasColumnName("DefinitionItemTypeId").IsRequired();
        builder.Property(ui => ui.Amount).HasColumnName("Amount").IsRequired();
        builder.Property(ui => ui.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ui => ui.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ui => ui.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ui => !ui.DeletedDate.HasValue);
    }
}
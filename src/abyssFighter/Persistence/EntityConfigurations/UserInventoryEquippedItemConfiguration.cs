using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserInventoryEquippedItemConfiguration : IEntityTypeConfiguration<UserInventoryEquippedItem>
{
    public void Configure(EntityTypeBuilder<UserInventoryEquippedItem> builder)
    {
        builder.ToTable("UserInventoryEquippedItems").HasKey(uiei => uiei.Id);

        builder.Property(uiei => uiei.Id).HasColumnName("Id").IsRequired();
        builder.Property(uiei => uiei.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uiei => uiei.UserHeroId).HasColumnName("UserHeroId").IsRequired();
        builder.Property(uiei => uiei.RightHand).HasColumnName("RightHand").IsRequired();
        builder.Property(uiei => uiei.LeftHand).HasColumnName("LeftHand").IsRequired();
        builder.Property(uiei => uiei.IsWeaponOneHanded).HasColumnName("IsWeaponOneHanded").IsRequired();
        builder.Property(uiei => uiei.ArmorId).HasColumnName("ArmorId").IsRequired();
        builder.Property(uiei => uiei.ConsumableSlot).HasColumnName("ConsumableSlot").IsRequired();
        builder.Property(uiei => uiei.Amount).HasColumnName("Amount").IsRequired();
        builder.Property(uiei => uiei.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(uiei => uiei.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(uiei => uiei.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(uiei => !uiei.DeletedDate.HasValue);
    }
}
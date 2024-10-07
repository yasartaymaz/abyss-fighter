using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserWalletConfiguration : IEntityTypeConfiguration<UserWallet>
{
    public void Configure(EntityTypeBuilder<UserWallet> builder)
    {
        builder.ToTable("UserWallets").HasKey(uw => uw.Id);

        builder.Property(uw => uw.Id).HasColumnName("Id").IsRequired();
        builder.Property(uw => uw.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uw => uw.DefinitionWalletTypeId).HasColumnName("DefinitionWalletTypeId").IsRequired();
        builder.Property(uw => uw.WalletAddress).HasColumnName("WalletAddress");
        builder.Property(uw => uw.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(uw => uw.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(uw => uw.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(uw => !uw.DeletedDate.HasValue);
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserPetDetailConfiguration : IEntityTypeConfiguration<UserPetDetail>
{
    public void Configure(EntityTypeBuilder<UserPetDetail> builder)
    {
        builder.ToTable("UserPetDetails").HasKey(upd => upd.Id);

        builder.Property(upd => upd.Id).HasColumnName("Id").IsRequired();
        builder.Property(upd => upd.UserPetId).HasColumnName("UserPetId").IsRequired();
        builder.Property(upd => upd.AttackPoints).HasColumnName("AttackPoints").IsRequired();
        builder.Property(upd => upd.DefencePoints).HasColumnName("DefencePoints").IsRequired();
        builder.Property(upd => upd.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(upd => upd.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(upd => upd.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(upd => !upd.DeletedDate.HasValue);
    }
}
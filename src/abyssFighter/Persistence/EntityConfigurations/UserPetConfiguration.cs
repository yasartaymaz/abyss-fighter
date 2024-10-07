using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserPetConfiguration : IEntityTypeConfiguration<UserPet>
{
    public void Configure(EntityTypeBuilder<UserPet> builder)
    {
        builder.ToTable("UserPets").HasKey(up => up.Id);

        builder.Property(up => up.Id).HasColumnName("Id").IsRequired();
        builder.Property(up => up.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(up => up.DefinitionPetId).HasColumnName("DefinitionPetId").IsRequired();
        builder.Property(up => up.HealthPoints).HasColumnName("HealthPoints").IsRequired();
        builder.Property(up => up.AttackPoints).HasColumnName("AttackPoints").IsRequired();
        builder.Property(up => up.DefencePoints).HasColumnName("DefencePoints").IsRequired();
        builder.Property(up => up.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(up => up.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(up => up.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(up => !up.DeletedDate.HasValue);
    }
}
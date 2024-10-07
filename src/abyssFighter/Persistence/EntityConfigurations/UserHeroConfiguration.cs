using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserHeroConfiguration : IEntityTypeConfiguration<UserHero>
{
    public void Configure(EntityTypeBuilder<UserHero> builder)
    {
        builder.ToTable("UserHeroes").HasKey(uh => uh.Id);

        builder.Property(uh => uh.Id).HasColumnName("Id").IsRequired();
        builder.Property(uh => uh.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uh => uh.Name).HasColumnName("Name");
        builder.Property(uh => uh.DefinitionHeroClassId).HasColumnName("DefinitionHeroClassId").IsRequired();
        builder.Property(uh => uh.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(uh => uh.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(uh => uh.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(uh => !uh.DeletedDate.HasValue);
    }
}
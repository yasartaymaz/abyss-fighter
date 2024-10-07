using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<DefinitionArmor> DefinitionArmors { get; set; }
    public DbSet<DefinitionArmorPart> DefinitionArmorParts { get; set; }
    public DbSet<DefinitionArmorType> DefinitionArmorTypes { get; set; }
    public DbSet<DefinitionHeroClass> DefinitionHeroClasses { get; set; }
    public DbSet<DefinitionItem> DefinitionItems { get; set; }
    public DbSet<DefinitionItemType> DefinitionItemTypes { get; set; }
    public DbSet<DefinitionPet> DefinitionPets { get; set; }
    public DbSet<DefinitionPetType> DefinitionPetTypes { get; set; }
    public DbSet<DefinitionWalletType> DefinitionWalletTypes { get; set; }
    public DbSet<DefinitionWeapon> DefinitionWeapons { get; set; }
    public DbSet<DefinitionWeaponType> DefinitionWeaponTypes { get; set; }
    public DbSet<UserHero> UserHeroes { get; set; }
    public DbSet<UserInventory> UserInventories { get; set; }
    public DbSet<UserInventoryEquippedItem> UserInventoryEquippedItems { get; set; }
    public DbSet<UserPet> UserPets { get; set; }
    public DbSet<UserPetDetail> UserPetDetails { get; set; }
    public DbSet<UserWallet> UserWallets { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

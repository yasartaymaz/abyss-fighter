using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
		string? connectionString = configuration.GetConnectionString("BaseDb");
		services.AddDbContext<BaseDbContext>(options => options.UseNpgsql(connectionString));
        //services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

  services.AddScoped<IDefinitionArmorRepository, DefinitionArmorRepository>();
  services.AddScoped<IDefinitionArmorPartRepository, DefinitionArmorPartRepository>();
  services.AddScoped<IDefinitionArmorTypeRepository, DefinitionArmorTypeRepository>();
  services.AddScoped<IDefinitionHeroClassRepository, DefinitionHeroClassRepository>();
  services.AddScoped<IDefinitionItemRepository, DefinitionItemRepository>();
  services.AddScoped<IDefinitionItemTypeRepository, DefinitionItemTypeRepository>();
  services.AddScoped<IDefinitionPetRepository, DefinitionPetRepository>();
  services.AddScoped<IDefinitionPetTypeRepository, DefinitionPetTypeRepository>();
  services.AddScoped<IDefinitionWalletTypeRepository, DefinitionWalletTypeRepository>();
  services.AddScoped<IDefinitionWeaponRepository, DefinitionWeaponRepository>();
  services.AddScoped<IDefinitionWeaponTypeRepository, DefinitionWeaponTypeRepository>();
  services.AddScoped<IUserHeroRepository, UserHeroRepository>();
  services.AddScoped<IUserInventoryRepository, UserInventoryRepository>();
  services.AddScoped<IUserInventoryEquippedItemRepository, UserInventoryEquippedItemRepository>();
  services.AddScoped<IUserPetRepository, UserPetRepository>();
  services.AddScoped<IUserPetDetailRepository, UserPetDetailRepository>();
  services.AddScoped<IUserWalletRepository, UserWalletRepository>();
        return services;
    }
}

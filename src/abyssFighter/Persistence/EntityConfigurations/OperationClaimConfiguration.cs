using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.DefinitionArmors.Constants;
using Application.Features.DefinitionArmorParts.Constants;
using Application.Features.DefinitionArmorTypes.Constants;
using Application.Features.DefinitionHeroClasses.Constants;
using Application.Features.DefinitionItems.Constants;
using Application.Features.DefinitionItemTypes.Constants;
using Application.Features.DefinitionPets.Constants;
using Application.Features.DefinitionPetTypes.Constants;
using Application.Features.DefinitionWalletTypes.Constants;
using Application.Features.DefinitionWeapons.Constants;
using Application.Features.DefinitionWeaponTypes.Constants;
using Application.Features.UserHeroes.Constants;
using Application.Features.UserInventories.Constants;
using Application.Features.UserInventoryEquippedItems.Constants;
using Application.Features.UserPets.Constants;
using Application.Features.UserPetDetails.Constants;
using Application.Features.UserWallets.Constants;
using Application.Features.DefinitionArmorTypes.Constants;
using Application.Features.DefinitionWeapons.Constants;




















namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region DefinitionArmors CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DefinitionArmorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DefinitionArmorsOperationClaims.Read },
                new() { Id = ++lastId, Name = DefinitionArmorsOperationClaims.Write },
                new() { Id = ++lastId, Name = DefinitionArmorsOperationClaims.Create },
                new() { Id = ++lastId, Name = DefinitionArmorsOperationClaims.Update },
                new() { Id = ++lastId, Name = DefinitionArmorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DefinitionArmorParts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DefinitionArmorPartsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DefinitionArmorPartsOperationClaims.Read },
                new() { Id = ++lastId, Name = DefinitionArmorPartsOperationClaims.Write },
                new() { Id = ++lastId, Name = DefinitionArmorPartsOperationClaims.Create },
                new() { Id = ++lastId, Name = DefinitionArmorPartsOperationClaims.Update },
                new() { Id = ++lastId, Name = DefinitionArmorPartsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DefinitionArmorTypes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DefinitionArmorTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = DefinitionArmorTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = DefinitionArmorTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = DefinitionArmorTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = DefinitionArmorTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = DefinitionArmorTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DefinitionHeroClasses CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DefinitionHeroClassesOperationClaims.Admin },
                new() { Id = ++lastId, Name = DefinitionHeroClassesOperationClaims.Read },
                new() { Id = ++lastId, Name = DefinitionHeroClassesOperationClaims.Write },
                new() { Id = ++lastId, Name = DefinitionHeroClassesOperationClaims.Create },
                new() { Id = ++lastId, Name = DefinitionHeroClassesOperationClaims.Update },
                new() { Id = ++lastId, Name = DefinitionHeroClassesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DefinitionItems CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DefinitionItemsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DefinitionItemsOperationClaims.Read },
                new() { Id = ++lastId, Name = DefinitionItemsOperationClaims.Write },
                new() { Id = ++lastId, Name = DefinitionItemsOperationClaims.Create },
                new() { Id = ++lastId, Name = DefinitionItemsOperationClaims.Update },
                new() { Id = ++lastId, Name = DefinitionItemsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DefinitionItemTypes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DefinitionItemTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = DefinitionItemTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = DefinitionItemTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = DefinitionItemTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = DefinitionItemTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = DefinitionItemTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DefinitionPets CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DefinitionPetsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DefinitionPetsOperationClaims.Read },
                new() { Id = ++lastId, Name = DefinitionPetsOperationClaims.Write },
                new() { Id = ++lastId, Name = DefinitionPetsOperationClaims.Create },
                new() { Id = ++lastId, Name = DefinitionPetsOperationClaims.Update },
                new() { Id = ++lastId, Name = DefinitionPetsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DefinitionPetTypes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DefinitionPetTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = DefinitionPetTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = DefinitionPetTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = DefinitionPetTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = DefinitionPetTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = DefinitionPetTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DefinitionWalletTypes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DefinitionWalletTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = DefinitionWalletTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = DefinitionWalletTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = DefinitionWalletTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = DefinitionWalletTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = DefinitionWalletTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DefinitionWeapons CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DefinitionWeaponsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DefinitionWeaponsOperationClaims.Read },
                new() { Id = ++lastId, Name = DefinitionWeaponsOperationClaims.Write },
                new() { Id = ++lastId, Name = DefinitionWeaponsOperationClaims.Create },
                new() { Id = ++lastId, Name = DefinitionWeaponsOperationClaims.Update },
                new() { Id = ++lastId, Name = DefinitionWeaponsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DefinitionWeaponTypes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DefinitionWeaponTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = DefinitionWeaponTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = DefinitionWeaponTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = DefinitionWeaponTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = DefinitionWeaponTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = DefinitionWeaponTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region UserHeroes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserHeroesOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserHeroesOperationClaims.Read },
                new() { Id = ++lastId, Name = UserHeroesOperationClaims.Write },
                new() { Id = ++lastId, Name = UserHeroesOperationClaims.Create },
                new() { Id = ++lastId, Name = UserHeroesOperationClaims.Update },
                new() { Id = ++lastId, Name = UserHeroesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region UserInventories CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserInventoriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserInventoriesOperationClaims.Read },
                new() { Id = ++lastId, Name = UserInventoriesOperationClaims.Write },
                new() { Id = ++lastId, Name = UserInventoriesOperationClaims.Create },
                new() { Id = ++lastId, Name = UserInventoriesOperationClaims.Update },
                new() { Id = ++lastId, Name = UserInventoriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region UserInventoryEquippedItems CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserInventoryEquippedItemsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserInventoryEquippedItemsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserInventoryEquippedItemsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserInventoryEquippedItemsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserInventoryEquippedItemsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserInventoryEquippedItemsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region UserPets CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserPetsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserPetsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserPetsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserPetsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserPetsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserPetsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region UserPetDetails CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserPetDetailsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserPetDetailsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserPetDetailsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserPetDetailsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserPetDetailsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserPetDetailsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region UserWallets CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserWalletsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserWalletsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserWalletsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserWalletsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserWalletsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserWalletsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DefinitionArmorTypes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DefinitionArmorTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = DefinitionArmorTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = DefinitionArmorTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = DefinitionArmorTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = DefinitionArmorTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = DefinitionArmorTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DefinitionWeapons CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DefinitionWeaponsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DefinitionWeaponsOperationClaims.Read },
                new() { Id = ++lastId, Name = DefinitionWeaponsOperationClaims.Write },
                new() { Id = ++lastId, Name = DefinitionWeaponsOperationClaims.Create },
                new() { Id = ++lastId, Name = DefinitionWeaponsOperationClaims.Update },
                new() { Id = ++lastId, Name = DefinitionWeaponsOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}

using Application.Features.Auth.Constants;
using Application.Services.Repositories;
using Application.Services.UserOperationClaims;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using NArchitecture.Core.Security.Enums;
using NArchitecture.Core.Security.Hashing;
using Nest;

namespace Application.Features.Auth.Rules;

public class AuthBusinessRules : BaseBusinessRules
{
	private readonly IUserRepository _userRepository;
	private readonly ILocalizationService _localizationService;
	private readonly IUserOperationClaimRepository _userOperationClaimRepository;
	private readonly IUserHeroRepository _userHeroRepository;
	private readonly IUserInventoryRepository _userInventoryRepository;
	private readonly IUserInventoryEquippedItemRepository _userInventoryEquippedItemRepository;
	private readonly IDefinitionHeroClassRepository _definitionHeroClassRepository;

	public AuthBusinessRules(IUserRepository userRepository, ILocalizationService localizationService, IUserOperationClaimRepository userOperationClaimRepository, IUserHeroRepository userHeroRepository, IUserInventoryRepository userInventoryRepository, IUserInventoryEquippedItemRepository userInventoryEquippedItemRepository, IDefinitionHeroClassRepository definitionHeroClassRepository)
	{
		_userRepository = userRepository;
		_localizationService = localizationService;
		_userOperationClaimRepository = userOperationClaimRepository;
		_userHeroRepository = userHeroRepository;
		_userInventoryRepository = userInventoryRepository;
		_userInventoryEquippedItemRepository = userInventoryEquippedItemRepository;
		_definitionHeroClassRepository = definitionHeroClassRepository;
	}

	private async Task throwBusinessException(string messageKey)
	{
		string message = await _localizationService.GetLocalizedAsync(messageKey, AuthMessages.SectionName);
		throw new BusinessException(message);
	}

	public async Task EmailAuthenticatorShouldBeExists(EmailAuthenticator? emailAuthenticator)
	{
		if (emailAuthenticator is null)
			await throwBusinessException(AuthMessages.EmailAuthenticatorDontExists);
	}

	public async Task OtpAuthenticatorShouldBeExists(OtpAuthenticator? otpAuthenticator)
	{
		if (otpAuthenticator is null)
			await throwBusinessException(AuthMessages.OtpAuthenticatorDontExists);
	}

	public async Task OtpAuthenticatorThatVerifiedShouldNotBeExists(OtpAuthenticator? otpAuthenticator)
	{
		if (otpAuthenticator is not null && otpAuthenticator.IsVerified)
			await throwBusinessException(AuthMessages.AlreadyVerifiedOtpAuthenticatorIsExists);
	}

	public async Task EmailAuthenticatorActivationKeyShouldBeExists(EmailAuthenticator emailAuthenticator)
	{
		if (emailAuthenticator.ActivationKey is null)
			await throwBusinessException(AuthMessages.EmailActivationKeyDontExists);
	}

	public async Task UserShouldBeExistsWhenSelected(User? user)
	{
		if (user == null)
			await throwBusinessException(AuthMessages.UserDontExists);
	}

	public async Task UserShouldNotBeHaveAuthenticator(User user)
	{
		if (user.AuthenticatorType != AuthenticatorType.None)
			await throwBusinessException(AuthMessages.UserHaveAlreadyAAuthenticator);
	}

	public async Task RefreshTokenShouldBeExists(RefreshToken? refreshToken)
	{
		if (refreshToken == null)
			await throwBusinessException(AuthMessages.RefreshDontExists);
	}

	public async Task RefreshTokenShouldBeActive(RefreshToken refreshToken)
	{
		if (refreshToken.RevokedDate != null && DateTime.UtcNow >= refreshToken.ExpirationDate)
			await throwBusinessException(AuthMessages.InvalidRefreshToken);
	}

	public async Task UserEmailShouldBeNotExists(string email)
	{
		bool doesExists = await _userRepository.AnyAsync(predicate: u => u.Email == email);
		if (doesExists)
			await throwBusinessException(AuthMessages.UserMailAlreadyExists);
	}

	public async Task UserPasswordShouldBeMatch(User user, string password)
	{
		if (!HashingHelper.VerifyPasswordHash(password, user!.PasswordHash, user.PasswordSalt))
			await throwBusinessException(AuthMessages.PasswordDontMatch);
	}

	public async Task AddUserOperationClaim(User createdUser)
	{
		if (createdUser == null)
		{
			await throwBusinessException(AuthMessages.UserDontExists);
		}

		await _userOperationClaimRepository.AddAsync(new UserOperationClaim
		{
			Id = Guid.NewGuid(),
			UserId = createdUser.Id,
			OperationClaimId = 1,
			CreatedDate = DateTime.Now
		});
	}

	public async Task AddUserHeroAndItems(Guid userId)
	{
		List<DefinitionHeroClass> heroClassList = await _definitionHeroClassRepository.Query().AsNoTracking().Where(x => x.DeletedDate == null).OrderBy(x => x.CreatedDate).ToListAsync();
		if (heroClassList != null)
		{
			Random rnd = new Random();
			int indexOfHeroClass = rnd.Next(heroClassList.Count);
			//DefinitionHeroClass chosenHeroClass = heroClassList[indexOfHeroClass];
			DefinitionHeroClass chosenHeroClass = heroClassList[0];

			UserHero userHero = new UserHero
			{
				Id = Guid.NewGuid(),
				UserId = userId,
				DefinitionHeroClassId = chosenHeroClass.Id,
				Name = "Name #" + rnd.Next(1000).ToString(),
				CreatedDate = DateTime.Now
			};

			await _userHeroRepository.AddAsync(userHero);

			//todo: add armor
			UserInventory inventoryArmor = new UserInventory
			{
				Id = Guid.NewGuid(),
				UserId = userId,
				UserHeroId = userHero.Id,
				DefinitionItemId = Guid.Parse("2c5b2e4e-25cf-4e9f-a4d1-fec4f0077e17"),
				DefinitionItemTypeId = Guid.Parse("55ab283b-05d9-49c2-83b9-6d351cc0fc00"),
				Amount = 1,
				CreatedDate = DateTime.Now
			};
			//todo: add weapon
			UserInventory inventory2hWeapon = new UserInventory//2h
			{
				Id = Guid.NewGuid(),
				UserId = userId,
				UserHeroId = userHero.Id,
				DefinitionItemId = Guid.Parse("e72e0462-dc66-4f38-b246-743d4eb865d9"),
				DefinitionItemTypeId = Guid.Parse("ddab4f9a-2c6b-4943-87d3-b77e6b3639a6"),
				Amount = 1,
				CreatedDate = DateTime.Now
			};
			UserInventory inventory1hWeapon = new UserInventory//1h
			{
				Id = Guid.NewGuid(),
				UserId = userId,
				UserHeroId = userHero.Id,
				DefinitionItemId = Guid.Parse("f7d0b358-13ec-4f6a-9090-f52e89e296e4"),
				DefinitionItemTypeId = Guid.Parse("ddab4f9a-2c6b-4943-87d3-b77e6b3639a6"),
				Amount = 1,
				CreatedDate = DateTime.Now
			};
			UserInventory inventoryShieldWeapon = new UserInventory//shield
			{
				Id = Guid.NewGuid(),
				UserId = userId,
				UserHeroId = userHero.Id,
				DefinitionItemId = Guid.Parse("ee2fb254-fd87-439d-a7d6-a423930ef83a"),
				DefinitionItemTypeId = Guid.Parse("ddab4f9a-2c6b-4943-87d3-b77e6b3639a6"),
				Amount = 1,
				CreatedDate = DateTime.Now
			};

			//for warrior
			await _userInventoryRepository.AddAsync(inventoryArmor);
			await _userInventoryRepository.AddAsync(inventory2hWeapon);

			//for knight
			//await _userInventoryRepository.AddAsync(inventoryArmor);
			//await _userInventoryRepository.AddAsync(inventory1hWeapon);
			//await _userInventoryRepository.AddAsync(inventoryShieldWeapon);

			//todo: UserInventoryEquippedItems kayitlari
			//for warrior

			//for knight
		}
	}
}

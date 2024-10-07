using Application.Features.UserInventories.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserInventories.Rules;

public class UserInventoryBusinessRules : BaseBusinessRules
{
    private readonly IUserInventoryRepository _userInventoryRepository;
    private readonly ILocalizationService _localizationService;

    public UserInventoryBusinessRules(IUserInventoryRepository userInventoryRepository, ILocalizationService localizationService)
    {
        _userInventoryRepository = userInventoryRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserInventoriesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserInventoryShouldExistWhenSelected(UserInventory? userInventory)
    {
        if (userInventory == null)
            await throwBusinessException(UserInventoriesBusinessMessages.UserInventoryNotExists);
    }

    public async Task UserInventoryIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserInventory? userInventory = await _userInventoryRepository.GetAsync(
            predicate: ui => ui.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserInventoryShouldExistWhenSelected(userInventory);
    }
}
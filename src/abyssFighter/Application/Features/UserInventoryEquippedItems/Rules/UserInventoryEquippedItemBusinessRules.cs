using Application.Features.UserInventoryEquippedItems.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserInventoryEquippedItems.Rules;

public class UserInventoryEquippedItemBusinessRules : BaseBusinessRules
{
    private readonly IUserInventoryEquippedItemRepository _userInventoryEquippedItemRepository;
    private readonly ILocalizationService _localizationService;

    public UserInventoryEquippedItemBusinessRules(IUserInventoryEquippedItemRepository userInventoryEquippedItemRepository, ILocalizationService localizationService)
    {
        _userInventoryEquippedItemRepository = userInventoryEquippedItemRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserInventoryEquippedItemsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserInventoryEquippedItemShouldExistWhenSelected(UserInventoryEquippedItem? userInventoryEquippedItem)
    {
        if (userInventoryEquippedItem == null)
            await throwBusinessException(UserInventoryEquippedItemsBusinessMessages.UserInventoryEquippedItemNotExists);
    }

    public async Task UserInventoryEquippedItemIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserInventoryEquippedItem? userInventoryEquippedItem = await _userInventoryEquippedItemRepository.GetAsync(
            predicate: uiei => uiei.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserInventoryEquippedItemShouldExistWhenSelected(userInventoryEquippedItem);
    }
}
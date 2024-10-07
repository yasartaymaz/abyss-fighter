using Application.Features.DefinitionItems.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.DefinitionItems.Rules;

public class DefinitionItemBusinessRules : BaseBusinessRules
{
    private readonly IDefinitionItemRepository _definitionItemRepository;
    private readonly ILocalizationService _localizationService;

    public DefinitionItemBusinessRules(IDefinitionItemRepository definitionItemRepository, ILocalizationService localizationService)
    {
        _definitionItemRepository = definitionItemRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DefinitionItemsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DefinitionItemShouldExistWhenSelected(DefinitionItem? definitionItem)
    {
        if (definitionItem == null)
            await throwBusinessException(DefinitionItemsBusinessMessages.DefinitionItemNotExists);
    }

    public async Task DefinitionItemIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        DefinitionItem? definitionItem = await _definitionItemRepository.GetAsync(
            predicate: di => di.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DefinitionItemShouldExistWhenSelected(definitionItem);
    }
}
using Application.Features.DefinitionItemTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.DefinitionItemTypes.Rules;

public class DefinitionItemTypeBusinessRules : BaseBusinessRules
{
    private readonly IDefinitionItemTypeRepository _definitionItemTypeRepository;
    private readonly ILocalizationService _localizationService;

    public DefinitionItemTypeBusinessRules(IDefinitionItemTypeRepository definitionItemTypeRepository, ILocalizationService localizationService)
    {
        _definitionItemTypeRepository = definitionItemTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DefinitionItemTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DefinitionItemTypeShouldExistWhenSelected(DefinitionItemType? definitionItemType)
    {
        if (definitionItemType == null)
            await throwBusinessException(DefinitionItemTypesBusinessMessages.DefinitionItemTypeNotExists);
    }

    public async Task DefinitionItemTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        DefinitionItemType? definitionItemType = await _definitionItemTypeRepository.GetAsync(
            predicate: dit => dit.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DefinitionItemTypeShouldExistWhenSelected(definitionItemType);
    }
}
using Application.Features.DefinitionPetTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.DefinitionPetTypes.Rules;

public class DefinitionPetTypeBusinessRules : BaseBusinessRules
{
    private readonly IDefinitionPetTypeRepository _definitionPetTypeRepository;
    private readonly ILocalizationService _localizationService;

    public DefinitionPetTypeBusinessRules(IDefinitionPetTypeRepository definitionPetTypeRepository, ILocalizationService localizationService)
    {
        _definitionPetTypeRepository = definitionPetTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DefinitionPetTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DefinitionPetTypeShouldExistWhenSelected(DefinitionPetType? definitionPetType)
    {
        if (definitionPetType == null)
            await throwBusinessException(DefinitionPetTypesBusinessMessages.DefinitionPetTypeNotExists);
    }

    public async Task DefinitionPetTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        DefinitionPetType? definitionPetType = await _definitionPetTypeRepository.GetAsync(
            predicate: dpt => dpt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DefinitionPetTypeShouldExistWhenSelected(definitionPetType);
    }
}
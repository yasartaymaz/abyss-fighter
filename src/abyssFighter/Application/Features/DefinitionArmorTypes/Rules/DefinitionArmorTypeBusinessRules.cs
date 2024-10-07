using Application.Features.DefinitionArmorTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.DefinitionArmorTypes.Rules;

public class DefinitionArmorTypeBusinessRules : BaseBusinessRules
{
    private readonly IDefinitionArmorTypeRepository _definitionArmorTypeRepository;
    private readonly ILocalizationService _localizationService;

    public DefinitionArmorTypeBusinessRules(IDefinitionArmorTypeRepository definitionArmorTypeRepository, ILocalizationService localizationService)
    {
        _definitionArmorTypeRepository = definitionArmorTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DefinitionArmorTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DefinitionArmorTypeShouldExistWhenSelected(DefinitionArmorType? definitionArmorType)
    {
        if (definitionArmorType == null)
            await throwBusinessException(DefinitionArmorTypesBusinessMessages.DefinitionArmorTypeNotExists);
    }

    public async Task DefinitionArmorTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        DefinitionArmorType? definitionArmorType = await _definitionArmorTypeRepository.GetAsync(
            predicate: dat => dat.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DefinitionArmorTypeShouldExistWhenSelected(definitionArmorType);
    }
}
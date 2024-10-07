using Application.Features.DefinitionWeaponTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.DefinitionWeaponTypes.Rules;

public class DefinitionWeaponTypeBusinessRules : BaseBusinessRules
{
    private readonly IDefinitionWeaponTypeRepository _definitionWeaponTypeRepository;
    private readonly ILocalizationService _localizationService;

    public DefinitionWeaponTypeBusinessRules(IDefinitionWeaponTypeRepository definitionWeaponTypeRepository, ILocalizationService localizationService)
    {
        _definitionWeaponTypeRepository = definitionWeaponTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DefinitionWeaponTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DefinitionWeaponTypeShouldExistWhenSelected(DefinitionWeaponType? definitionWeaponType)
    {
        if (definitionWeaponType == null)
            await throwBusinessException(DefinitionWeaponTypesBusinessMessages.DefinitionWeaponTypeNotExists);
    }

    public async Task DefinitionWeaponTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        DefinitionWeaponType? definitionWeaponType = await _definitionWeaponTypeRepository.GetAsync(
            predicate: dwt => dwt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DefinitionWeaponTypeShouldExistWhenSelected(definitionWeaponType);
    }
}
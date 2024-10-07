using Application.Features.DefinitionWeapons.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.DefinitionWeapons.Rules;

public class DefinitionWeaponBusinessRules : BaseBusinessRules
{
    private readonly IDefinitionWeaponRepository _definitionWeaponRepository;
    private readonly ILocalizationService _localizationService;

    public DefinitionWeaponBusinessRules(IDefinitionWeaponRepository definitionWeaponRepository, ILocalizationService localizationService)
    {
        _definitionWeaponRepository = definitionWeaponRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DefinitionWeaponsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DefinitionWeaponShouldExistWhenSelected(DefinitionWeapon? definitionWeapon)
    {
        if (definitionWeapon == null)
            await throwBusinessException(DefinitionWeaponsBusinessMessages.DefinitionWeaponNotExists);
    }

    public async Task DefinitionWeaponIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        DefinitionWeapon? definitionWeapon = await _definitionWeaponRepository.GetAsync(
            predicate: dw => dw.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DefinitionWeaponShouldExistWhenSelected(definitionWeapon);
    }
}
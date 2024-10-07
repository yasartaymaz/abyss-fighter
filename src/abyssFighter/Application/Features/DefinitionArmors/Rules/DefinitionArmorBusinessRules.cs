using Application.Features.DefinitionArmors.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.DefinitionArmors.Rules;

public class DefinitionArmorBusinessRules : BaseBusinessRules
{
    private readonly IDefinitionArmorRepository _definitionArmorRepository;
    private readonly ILocalizationService _localizationService;

    public DefinitionArmorBusinessRules(IDefinitionArmorRepository definitionArmorRepository, ILocalizationService localizationService)
    {
        _definitionArmorRepository = definitionArmorRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DefinitionArmorsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DefinitionArmorShouldExistWhenSelected(DefinitionArmor? definitionArmor)
    {
        if (definitionArmor == null)
            await throwBusinessException(DefinitionArmorsBusinessMessages.DefinitionArmorNotExists);
    }

    public async Task DefinitionArmorIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        DefinitionArmor? definitionArmor = await _definitionArmorRepository.GetAsync(
            predicate: da => da.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DefinitionArmorShouldExistWhenSelected(definitionArmor);
    }
}
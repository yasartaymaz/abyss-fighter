using Application.Features.DefinitionArmorParts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.DefinitionArmorParts.Rules;

public class DefinitionArmorPartBusinessRules : BaseBusinessRules
{
    private readonly IDefinitionArmorPartRepository _definitionArmorPartRepository;
    private readonly ILocalizationService _localizationService;

    public DefinitionArmorPartBusinessRules(IDefinitionArmorPartRepository definitionArmorPartRepository, ILocalizationService localizationService)
    {
        _definitionArmorPartRepository = definitionArmorPartRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DefinitionArmorPartsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DefinitionArmorPartShouldExistWhenSelected(DefinitionArmorPart? definitionArmorPart)
    {
        if (definitionArmorPart == null)
            await throwBusinessException(DefinitionArmorPartsBusinessMessages.DefinitionArmorPartNotExists);
    }

    public async Task DefinitionArmorPartIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        DefinitionArmorPart? definitionArmorPart = await _definitionArmorPartRepository.GetAsync(
            predicate: dap => dap.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DefinitionArmorPartShouldExistWhenSelected(definitionArmorPart);
    }
}
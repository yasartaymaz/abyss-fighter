using Application.Features.DefinitionWalletTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.DefinitionWalletTypes.Rules;

public class DefinitionWalletTypeBusinessRules : BaseBusinessRules
{
    private readonly IDefinitionWalletTypeRepository _definitionWalletTypeRepository;
    private readonly ILocalizationService _localizationService;

    public DefinitionWalletTypeBusinessRules(IDefinitionWalletTypeRepository definitionWalletTypeRepository, ILocalizationService localizationService)
    {
        _definitionWalletTypeRepository = definitionWalletTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DefinitionWalletTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DefinitionWalletTypeShouldExistWhenSelected(DefinitionWalletType? definitionWalletType)
    {
        if (definitionWalletType == null)
            await throwBusinessException(DefinitionWalletTypesBusinessMessages.DefinitionWalletTypeNotExists);
    }

    public async Task DefinitionWalletTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        DefinitionWalletType? definitionWalletType = await _definitionWalletTypeRepository.GetAsync(
            predicate: dwt => dwt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DefinitionWalletTypeShouldExistWhenSelected(definitionWalletType);
    }
}
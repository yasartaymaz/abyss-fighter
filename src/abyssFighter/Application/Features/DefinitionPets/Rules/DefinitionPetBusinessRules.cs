using Application.Features.DefinitionPets.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.DefinitionPets.Rules;

public class DefinitionPetBusinessRules : BaseBusinessRules
{
    private readonly IDefinitionPetRepository _definitionPetRepository;
    private readonly ILocalizationService _localizationService;

    public DefinitionPetBusinessRules(IDefinitionPetRepository definitionPetRepository, ILocalizationService localizationService)
    {
        _definitionPetRepository = definitionPetRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DefinitionPetsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DefinitionPetShouldExistWhenSelected(DefinitionPet? definitionPet)
    {
        if (definitionPet == null)
            await throwBusinessException(DefinitionPetsBusinessMessages.DefinitionPetNotExists);
    }

    public async Task DefinitionPetIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        DefinitionPet? definitionPet = await _definitionPetRepository.GetAsync(
            predicate: dp => dp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DefinitionPetShouldExistWhenSelected(definitionPet);
    }
}
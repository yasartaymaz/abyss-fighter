using Application.Features.DefinitionHeroClasses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.DefinitionHeroClasses.Rules;

public class DefinitionHeroClassBusinessRules : BaseBusinessRules
{
    private readonly IDefinitionHeroClassRepository _definitionHeroClassRepository;
    private readonly ILocalizationService _localizationService;

    public DefinitionHeroClassBusinessRules(IDefinitionHeroClassRepository definitionHeroClassRepository, ILocalizationService localizationService)
    {
        _definitionHeroClassRepository = definitionHeroClassRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DefinitionHeroClassesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DefinitionHeroClassShouldExistWhenSelected(DefinitionHeroClass? definitionHeroClass)
    {
        if (definitionHeroClass == null)
            await throwBusinessException(DefinitionHeroClassesBusinessMessages.DefinitionHeroClassNotExists);
    }

    public async Task DefinitionHeroClassIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        DefinitionHeroClass? definitionHeroClass = await _definitionHeroClassRepository.GetAsync(
            predicate: dhc => dhc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DefinitionHeroClassShouldExistWhenSelected(definitionHeroClass);
    }
}
using Application.Features.UserHeroes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserHeroes.Rules;

public class UserHeroBusinessRules : BaseBusinessRules
{
    private readonly IUserHeroRepository _userHeroRepository;
    private readonly ILocalizationService _localizationService;

    public UserHeroBusinessRules(IUserHeroRepository userHeroRepository, ILocalizationService localizationService)
    {
        _userHeroRepository = userHeroRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserHeroesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserHeroShouldExistWhenSelected(UserHero? userHero)
    {
        if (userHero == null)
            await throwBusinessException(UserHeroesBusinessMessages.UserHeroNotExists);
    }

    public async Task UserHeroIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserHero? userHero = await _userHeroRepository.GetAsync(
            predicate: uh => uh.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserHeroShouldExistWhenSelected(userHero);
    }
}
using Application.Features.UserPets.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserPets.Rules;

public class UserPetBusinessRules : BaseBusinessRules
{
    private readonly IUserPetRepository _userPetRepository;
    private readonly ILocalizationService _localizationService;

    public UserPetBusinessRules(IUserPetRepository userPetRepository, ILocalizationService localizationService)
    {
        _userPetRepository = userPetRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserPetsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserPetShouldExistWhenSelected(UserPet? userPet)
    {
        if (userPet == null)
            await throwBusinessException(UserPetsBusinessMessages.UserPetNotExists);
    }

    public async Task UserPetIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserPet? userPet = await _userPetRepository.GetAsync(
            predicate: up => up.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserPetShouldExistWhenSelected(userPet);
    }
}
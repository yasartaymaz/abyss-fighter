using Application.Features.UserPetDetails.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserPetDetails.Rules;

public class UserPetDetailBusinessRules : BaseBusinessRules
{
    private readonly IUserPetDetailRepository _userPetDetailRepository;
    private readonly ILocalizationService _localizationService;

    public UserPetDetailBusinessRules(IUserPetDetailRepository userPetDetailRepository, ILocalizationService localizationService)
    {
        _userPetDetailRepository = userPetDetailRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserPetDetailsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserPetDetailShouldExistWhenSelected(UserPetDetail? userPetDetail)
    {
        if (userPetDetail == null)
            await throwBusinessException(UserPetDetailsBusinessMessages.UserPetDetailNotExists);
    }

    public async Task UserPetDetailIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserPetDetail? userPetDetail = await _userPetDetailRepository.GetAsync(
            predicate: upd => upd.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserPetDetailShouldExistWhenSelected(userPetDetail);
    }
}
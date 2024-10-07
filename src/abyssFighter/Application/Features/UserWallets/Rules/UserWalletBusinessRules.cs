using Application.Features.UserWallets.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserWallets.Rules;

public class UserWalletBusinessRules : BaseBusinessRules
{
    private readonly IUserWalletRepository _userWalletRepository;
    private readonly ILocalizationService _localizationService;

    public UserWalletBusinessRules(IUserWalletRepository userWalletRepository, ILocalizationService localizationService)
    {
        _userWalletRepository = userWalletRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserWalletsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserWalletShouldExistWhenSelected(UserWallet? userWallet)
    {
        if (userWallet == null)
            await throwBusinessException(UserWalletsBusinessMessages.UserWalletNotExists);
    }

    public async Task UserWalletIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserWallet? userWallet = await _userWalletRepository.GetAsync(
            predicate: uw => uw.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserWalletShouldExistWhenSelected(userWallet);
    }
}
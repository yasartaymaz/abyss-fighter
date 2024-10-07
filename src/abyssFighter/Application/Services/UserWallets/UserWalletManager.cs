using Application.Features.UserWallets.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserWallets;

public class UserWalletManager : IUserWalletService
{
    private readonly IUserWalletRepository _userWalletRepository;
    private readonly UserWalletBusinessRules _userWalletBusinessRules;

    public UserWalletManager(IUserWalletRepository userWalletRepository, UserWalletBusinessRules userWalletBusinessRules)
    {
        _userWalletRepository = userWalletRepository;
        _userWalletBusinessRules = userWalletBusinessRules;
    }

    public async Task<UserWallet?> GetAsync(
        Expression<Func<UserWallet, bool>> predicate,
        Func<IQueryable<UserWallet>, IIncludableQueryable<UserWallet, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserWallet? userWallet = await _userWalletRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userWallet;
    }

    public async Task<IPaginate<UserWallet>?> GetListAsync(
        Expression<Func<UserWallet, bool>>? predicate = null,
        Func<IQueryable<UserWallet>, IOrderedQueryable<UserWallet>>? orderBy = null,
        Func<IQueryable<UserWallet>, IIncludableQueryable<UserWallet, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserWallet> userWalletList = await _userWalletRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userWalletList;
    }

    public async Task<UserWallet> AddAsync(UserWallet userWallet)
    {
        UserWallet addedUserWallet = await _userWalletRepository.AddAsync(userWallet);

        return addedUserWallet;
    }

    public async Task<UserWallet> UpdateAsync(UserWallet userWallet)
    {
        UserWallet updatedUserWallet = await _userWalletRepository.UpdateAsync(userWallet);

        return updatedUserWallet;
    }

    public async Task<UserWallet> DeleteAsync(UserWallet userWallet, bool permanent = false)
    {
        UserWallet deletedUserWallet = await _userWalletRepository.DeleteAsync(userWallet);

        return deletedUserWallet;
    }
}

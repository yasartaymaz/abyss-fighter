using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserWallets;

public interface IUserWalletService
{
    Task<UserWallet?> GetAsync(
        Expression<Func<UserWallet, bool>> predicate,
        Func<IQueryable<UserWallet>, IIncludableQueryable<UserWallet, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserWallet>?> GetListAsync(
        Expression<Func<UserWallet, bool>>? predicate = null,
        Func<IQueryable<UserWallet>, IOrderedQueryable<UserWallet>>? orderBy = null,
        Func<IQueryable<UserWallet>, IIncludableQueryable<UserWallet, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserWallet> AddAsync(UserWallet userWallet);
    Task<UserWallet> UpdateAsync(UserWallet userWallet);
    Task<UserWallet> DeleteAsync(UserWallet userWallet, bool permanent = false);
}

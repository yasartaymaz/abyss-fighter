using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserInventoryEquippedItems;

public interface IUserInventoryEquippedItemService
{
    Task<UserInventoryEquippedItem?> GetAsync(
        Expression<Func<UserInventoryEquippedItem, bool>> predicate,
        Func<IQueryable<UserInventoryEquippedItem>, IIncludableQueryable<UserInventoryEquippedItem, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserInventoryEquippedItem>?> GetListAsync(
        Expression<Func<UserInventoryEquippedItem, bool>>? predicate = null,
        Func<IQueryable<UserInventoryEquippedItem>, IOrderedQueryable<UserInventoryEquippedItem>>? orderBy = null,
        Func<IQueryable<UserInventoryEquippedItem>, IIncludableQueryable<UserInventoryEquippedItem, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserInventoryEquippedItem> AddAsync(UserInventoryEquippedItem userInventoryEquippedItem);
    Task<UserInventoryEquippedItem> UpdateAsync(UserInventoryEquippedItem userInventoryEquippedItem);
    Task<UserInventoryEquippedItem> DeleteAsync(UserInventoryEquippedItem userInventoryEquippedItem, bool permanent = false);
}

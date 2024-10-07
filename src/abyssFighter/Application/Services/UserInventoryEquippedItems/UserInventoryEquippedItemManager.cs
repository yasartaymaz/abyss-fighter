using Application.Features.UserInventoryEquippedItems.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserInventoryEquippedItems;

public class UserInventoryEquippedItemManager : IUserInventoryEquippedItemService
{
    private readonly IUserInventoryEquippedItemRepository _userInventoryEquippedItemRepository;
    private readonly UserInventoryEquippedItemBusinessRules _userInventoryEquippedItemBusinessRules;

    public UserInventoryEquippedItemManager(IUserInventoryEquippedItemRepository userInventoryEquippedItemRepository, UserInventoryEquippedItemBusinessRules userInventoryEquippedItemBusinessRules)
    {
        _userInventoryEquippedItemRepository = userInventoryEquippedItemRepository;
        _userInventoryEquippedItemBusinessRules = userInventoryEquippedItemBusinessRules;
    }

    public async Task<UserInventoryEquippedItem?> GetAsync(
        Expression<Func<UserInventoryEquippedItem, bool>> predicate,
        Func<IQueryable<UserInventoryEquippedItem>, IIncludableQueryable<UserInventoryEquippedItem, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserInventoryEquippedItem? userInventoryEquippedItem = await _userInventoryEquippedItemRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userInventoryEquippedItem;
    }

    public async Task<IPaginate<UserInventoryEquippedItem>?> GetListAsync(
        Expression<Func<UserInventoryEquippedItem, bool>>? predicate = null,
        Func<IQueryable<UserInventoryEquippedItem>, IOrderedQueryable<UserInventoryEquippedItem>>? orderBy = null,
        Func<IQueryable<UserInventoryEquippedItem>, IIncludableQueryable<UserInventoryEquippedItem, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserInventoryEquippedItem> userInventoryEquippedItemList = await _userInventoryEquippedItemRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userInventoryEquippedItemList;
    }

    public async Task<UserInventoryEquippedItem> AddAsync(UserInventoryEquippedItem userInventoryEquippedItem)
    {
        UserInventoryEquippedItem addedUserInventoryEquippedItem = await _userInventoryEquippedItemRepository.AddAsync(userInventoryEquippedItem);

        return addedUserInventoryEquippedItem;
    }

    public async Task<UserInventoryEquippedItem> UpdateAsync(UserInventoryEquippedItem userInventoryEquippedItem)
    {
        UserInventoryEquippedItem updatedUserInventoryEquippedItem = await _userInventoryEquippedItemRepository.UpdateAsync(userInventoryEquippedItem);

        return updatedUserInventoryEquippedItem;
    }

    public async Task<UserInventoryEquippedItem> DeleteAsync(UserInventoryEquippedItem userInventoryEquippedItem, bool permanent = false)
    {
        UserInventoryEquippedItem deletedUserInventoryEquippedItem = await _userInventoryEquippedItemRepository.DeleteAsync(userInventoryEquippedItem);

        return deletedUserInventoryEquippedItem;
    }
}

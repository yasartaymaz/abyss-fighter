using Application.Features.UserInventories.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserInventories;

public class UserInventoryManager : IUserInventoryService
{
    private readonly IUserInventoryRepository _userInventoryRepository;
    private readonly UserInventoryBusinessRules _userInventoryBusinessRules;

    public UserInventoryManager(IUserInventoryRepository userInventoryRepository, UserInventoryBusinessRules userInventoryBusinessRules)
    {
        _userInventoryRepository = userInventoryRepository;
        _userInventoryBusinessRules = userInventoryBusinessRules;
    }

    public async Task<UserInventory?> GetAsync(
        Expression<Func<UserInventory, bool>> predicate,
        Func<IQueryable<UserInventory>, IIncludableQueryable<UserInventory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserInventory? userInventory = await _userInventoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userInventory;
    }

    public async Task<IPaginate<UserInventory>?> GetListAsync(
        Expression<Func<UserInventory, bool>>? predicate = null,
        Func<IQueryable<UserInventory>, IOrderedQueryable<UserInventory>>? orderBy = null,
        Func<IQueryable<UserInventory>, IIncludableQueryable<UserInventory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserInventory> userInventoryList = await _userInventoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userInventoryList;
    }

    public async Task<UserInventory> AddAsync(UserInventory userInventory)
    {
        UserInventory addedUserInventory = await _userInventoryRepository.AddAsync(userInventory);

        return addedUserInventory;
    }

    public async Task<UserInventory> UpdateAsync(UserInventory userInventory)
    {
        UserInventory updatedUserInventory = await _userInventoryRepository.UpdateAsync(userInventory);

        return updatedUserInventory;
    }

    public async Task<UserInventory> DeleteAsync(UserInventory userInventory, bool permanent = false)
    {
        UserInventory deletedUserInventory = await _userInventoryRepository.DeleteAsync(userInventory);

        return deletedUserInventory;
    }
}

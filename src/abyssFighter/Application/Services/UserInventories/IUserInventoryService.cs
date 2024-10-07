using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserInventories;

public interface IUserInventoryService
{
    Task<UserInventory?> GetAsync(
        Expression<Func<UserInventory, bool>> predicate,
        Func<IQueryable<UserInventory>, IIncludableQueryable<UserInventory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserInventory>?> GetListAsync(
        Expression<Func<UserInventory, bool>>? predicate = null,
        Func<IQueryable<UserInventory>, IOrderedQueryable<UserInventory>>? orderBy = null,
        Func<IQueryable<UserInventory>, IIncludableQueryable<UserInventory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserInventory> AddAsync(UserInventory userInventory);
    Task<UserInventory> UpdateAsync(UserInventory userInventory);
    Task<UserInventory> DeleteAsync(UserInventory userInventory, bool permanent = false);
}

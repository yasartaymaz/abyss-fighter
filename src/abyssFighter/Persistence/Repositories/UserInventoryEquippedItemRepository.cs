using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserInventoryEquippedItemRepository : EfRepositoryBase<UserInventoryEquippedItem, Guid, BaseDbContext>, IUserInventoryEquippedItemRepository
{
    public UserInventoryEquippedItemRepository(BaseDbContext context) : base(context)
    {
    }
}
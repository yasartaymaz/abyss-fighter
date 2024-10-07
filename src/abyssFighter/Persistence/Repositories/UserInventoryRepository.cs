using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserInventoryRepository : EfRepositoryBase<UserInventory, Guid, BaseDbContext>, IUserInventoryRepository
{
    public UserInventoryRepository(BaseDbContext context) : base(context)
    {
    }
}
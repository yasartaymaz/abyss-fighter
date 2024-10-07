using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserInventoryEquippedItemRepository : IAsyncRepository<UserInventoryEquippedItem, Guid>, IRepository<UserInventoryEquippedItem, Guid>
{
}
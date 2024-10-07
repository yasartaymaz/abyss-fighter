using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserInventoryRepository : IAsyncRepository<UserInventory, Guid>, IRepository<UserInventory, Guid>
{
}
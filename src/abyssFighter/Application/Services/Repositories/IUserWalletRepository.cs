using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserWalletRepository : IAsyncRepository<UserWallet, Guid>, IRepository<UserWallet, Guid>
{
}
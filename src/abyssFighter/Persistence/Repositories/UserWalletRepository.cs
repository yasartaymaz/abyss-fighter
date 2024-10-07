using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserWalletRepository : EfRepositoryBase<UserWallet, Guid, BaseDbContext>, IUserWalletRepository
{
    public UserWalletRepository(BaseDbContext context) : base(context)
    {
    }
}
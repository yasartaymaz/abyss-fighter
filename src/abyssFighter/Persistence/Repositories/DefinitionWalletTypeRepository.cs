using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DefinitionWalletTypeRepository : EfRepositoryBase<DefinitionWalletType, Guid, BaseDbContext>, IDefinitionWalletTypeRepository
{
    public DefinitionWalletTypeRepository(BaseDbContext context) : base(context)
    {
    }
}
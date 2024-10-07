using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DefinitionArmorRepository : EfRepositoryBase<DefinitionArmor, Guid, BaseDbContext>, IDefinitionArmorRepository
{
    public DefinitionArmorRepository(BaseDbContext context) : base(context)
    {
    }
}
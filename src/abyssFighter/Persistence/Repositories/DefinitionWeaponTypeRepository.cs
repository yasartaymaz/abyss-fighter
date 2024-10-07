using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DefinitionWeaponTypeRepository : EfRepositoryBase<DefinitionWeaponType, Guid, BaseDbContext>, IDefinitionWeaponTypeRepository
{
    public DefinitionWeaponTypeRepository(BaseDbContext context) : base(context)
    {
    }
}
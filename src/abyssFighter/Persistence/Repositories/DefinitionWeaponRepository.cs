using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DefinitionWeaponRepository : EfRepositoryBase<DefinitionWeapon, Guid, BaseDbContext>, IDefinitionWeaponRepository
{
    public DefinitionWeaponRepository(BaseDbContext context) : base(context)
    {
    }
}
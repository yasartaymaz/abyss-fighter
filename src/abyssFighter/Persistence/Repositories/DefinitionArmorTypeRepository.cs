using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DefinitionArmorTypeRepository : EfRepositoryBase<DefinitionArmorType, Guid, BaseDbContext>, IDefinitionArmorTypeRepository
{
    public DefinitionArmorTypeRepository(BaseDbContext context) : base(context)
    {
    }
}
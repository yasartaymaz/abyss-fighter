using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DefinitionItemTypeRepository : EfRepositoryBase<DefinitionItemType, Guid, BaseDbContext>, IDefinitionItemTypeRepository
{
    public DefinitionItemTypeRepository(BaseDbContext context) : base(context)
    {
    }
}
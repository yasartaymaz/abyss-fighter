using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DefinitionItemRepository : EfRepositoryBase<DefinitionItem, Guid, BaseDbContext>, IDefinitionItemRepository
{
    public DefinitionItemRepository(BaseDbContext context) : base(context)
    {
    }
}
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DefinitionHeroClassRepository : EfRepositoryBase<DefinitionHeroClass, Guid, BaseDbContext>, IDefinitionHeroClassRepository
{
    public DefinitionHeroClassRepository(BaseDbContext context) : base(context)
    {
    }
}
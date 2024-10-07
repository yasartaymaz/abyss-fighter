using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DefinitionArmorPartRepository : EfRepositoryBase<DefinitionArmorPart, Guid, BaseDbContext>, IDefinitionArmorPartRepository
{
    public DefinitionArmorPartRepository(BaseDbContext context) : base(context)
    {
    }
}
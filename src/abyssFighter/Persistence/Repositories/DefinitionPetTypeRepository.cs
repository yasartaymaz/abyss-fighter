using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DefinitionPetTypeRepository : EfRepositoryBase<DefinitionPetType, Guid, BaseDbContext>, IDefinitionPetTypeRepository
{
    public DefinitionPetTypeRepository(BaseDbContext context) : base(context)
    {
    }
}
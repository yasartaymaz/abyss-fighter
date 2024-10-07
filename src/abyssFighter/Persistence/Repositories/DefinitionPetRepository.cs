using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DefinitionPetRepository : EfRepositoryBase<DefinitionPet, Guid, BaseDbContext>, IDefinitionPetRepository
{
    public DefinitionPetRepository(BaseDbContext context) : base(context)
    {
    }
}
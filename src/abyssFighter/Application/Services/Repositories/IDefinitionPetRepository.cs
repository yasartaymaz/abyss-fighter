using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDefinitionPetRepository : IAsyncRepository<DefinitionPet, Guid>, IRepository<DefinitionPet, Guid>
{
}
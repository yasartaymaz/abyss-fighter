using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDefinitionPetTypeRepository : IAsyncRepository<DefinitionPetType, Guid>, IRepository<DefinitionPetType, Guid>
{
}
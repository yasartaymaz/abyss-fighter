using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDefinitionHeroClassRepository : IAsyncRepository<DefinitionHeroClass, Guid>, IRepository<DefinitionHeroClass, Guid>
{
}
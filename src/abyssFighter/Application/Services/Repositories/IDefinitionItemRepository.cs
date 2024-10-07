using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDefinitionItemRepository : IAsyncRepository<DefinitionItem, Guid>, IRepository<DefinitionItem, Guid>
{
}
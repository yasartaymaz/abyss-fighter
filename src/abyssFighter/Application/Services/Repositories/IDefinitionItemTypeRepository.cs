using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDefinitionItemTypeRepository : IAsyncRepository<DefinitionItemType, Guid>, IRepository<DefinitionItemType, Guid>
{
}
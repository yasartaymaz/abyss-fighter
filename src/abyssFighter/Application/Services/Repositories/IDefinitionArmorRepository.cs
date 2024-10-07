using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDefinitionArmorRepository : IAsyncRepository<DefinitionArmor, Guid>, IRepository<DefinitionArmor, Guid>
{
}
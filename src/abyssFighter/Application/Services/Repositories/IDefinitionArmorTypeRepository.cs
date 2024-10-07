using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDefinitionArmorTypeRepository : IAsyncRepository<DefinitionArmorType, Guid>, IRepository<DefinitionArmorType, Guid>
{
}
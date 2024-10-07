using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDefinitionArmorPartRepository : IAsyncRepository<DefinitionArmorPart, Guid>, IRepository<DefinitionArmorPart, Guid>
{
}
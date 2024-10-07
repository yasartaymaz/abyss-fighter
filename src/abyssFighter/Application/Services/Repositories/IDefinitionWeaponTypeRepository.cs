using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDefinitionWeaponTypeRepository : IAsyncRepository<DefinitionWeaponType, Guid>, IRepository<DefinitionWeaponType, Guid>
{
}
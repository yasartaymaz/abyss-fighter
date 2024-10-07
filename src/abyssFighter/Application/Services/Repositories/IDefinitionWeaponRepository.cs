using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDefinitionWeaponRepository : IAsyncRepository<DefinitionWeapon, Guid>, IRepository<DefinitionWeapon, Guid>
{
}
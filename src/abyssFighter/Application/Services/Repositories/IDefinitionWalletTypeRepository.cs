using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDefinitionWalletTypeRepository : IAsyncRepository<DefinitionWalletType, Guid>, IRepository<DefinitionWalletType, Guid>
{
}
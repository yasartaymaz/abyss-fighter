using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserHeroRepository : IAsyncRepository<UserHero, Guid>, IRepository<UserHero, Guid>
{
}
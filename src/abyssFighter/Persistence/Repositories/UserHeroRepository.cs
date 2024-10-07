using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserHeroRepository : EfRepositoryBase<UserHero, Guid, BaseDbContext>, IUserHeroRepository
{
    public UserHeroRepository(BaseDbContext context) : base(context)
    {
    }
}
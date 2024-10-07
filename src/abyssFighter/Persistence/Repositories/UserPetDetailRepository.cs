using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserPetDetailRepository : EfRepositoryBase<UserPetDetail, Guid, BaseDbContext>, IUserPetDetailRepository
{
    public UserPetDetailRepository(BaseDbContext context) : base(context)
    {
    }
}
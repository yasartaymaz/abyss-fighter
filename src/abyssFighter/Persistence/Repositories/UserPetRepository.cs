using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserPetRepository : EfRepositoryBase<UserPet, Guid, BaseDbContext>, IUserPetRepository
{
    public UserPetRepository(BaseDbContext context) : base(context)
    {
    }
}
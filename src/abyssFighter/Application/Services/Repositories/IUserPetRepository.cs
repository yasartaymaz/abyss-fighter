using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserPetRepository : IAsyncRepository<UserPet, Guid>, IRepository<UserPet, Guid>
{
}
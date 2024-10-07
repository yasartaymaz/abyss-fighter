using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserPetDetailRepository : IAsyncRepository<UserPetDetail, Guid>, IRepository<UserPetDetail, Guid>
{
}
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserPets;

public interface IUserPetService
{
    Task<UserPet?> GetAsync(
        Expression<Func<UserPet, bool>> predicate,
        Func<IQueryable<UserPet>, IIncludableQueryable<UserPet, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserPet>?> GetListAsync(
        Expression<Func<UserPet, bool>>? predicate = null,
        Func<IQueryable<UserPet>, IOrderedQueryable<UserPet>>? orderBy = null,
        Func<IQueryable<UserPet>, IIncludableQueryable<UserPet, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserPet> AddAsync(UserPet userPet);
    Task<UserPet> UpdateAsync(UserPet userPet);
    Task<UserPet> DeleteAsync(UserPet userPet, bool permanent = false);
}

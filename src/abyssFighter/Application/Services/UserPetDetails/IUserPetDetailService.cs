using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserPetDetails;

public interface IUserPetDetailService
{
    Task<UserPetDetail?> GetAsync(
        Expression<Func<UserPetDetail, bool>> predicate,
        Func<IQueryable<UserPetDetail>, IIncludableQueryable<UserPetDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserPetDetail>?> GetListAsync(
        Expression<Func<UserPetDetail, bool>>? predicate = null,
        Func<IQueryable<UserPetDetail>, IOrderedQueryable<UserPetDetail>>? orderBy = null,
        Func<IQueryable<UserPetDetail>, IIncludableQueryable<UserPetDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserPetDetail> AddAsync(UserPetDetail userPetDetail);
    Task<UserPetDetail> UpdateAsync(UserPetDetail userPetDetail);
    Task<UserPetDetail> DeleteAsync(UserPetDetail userPetDetail, bool permanent = false);
}

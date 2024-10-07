using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserHeroes;

public interface IUserHeroService
{
    Task<UserHero?> GetAsync(
        Expression<Func<UserHero, bool>> predicate,
        Func<IQueryable<UserHero>, IIncludableQueryable<UserHero, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserHero>?> GetListAsync(
        Expression<Func<UserHero, bool>>? predicate = null,
        Func<IQueryable<UserHero>, IOrderedQueryable<UserHero>>? orderBy = null,
        Func<IQueryable<UserHero>, IIncludableQueryable<UserHero, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserHero> AddAsync(UserHero userHero);
    Task<UserHero> UpdateAsync(UserHero userHero);
    Task<UserHero> DeleteAsync(UserHero userHero, bool permanent = false);
}

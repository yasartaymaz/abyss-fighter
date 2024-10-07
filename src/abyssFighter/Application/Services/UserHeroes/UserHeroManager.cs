using Application.Features.UserHeroes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserHeroes;

public class UserHeroManager : IUserHeroService
{
    private readonly IUserHeroRepository _userHeroRepository;
    private readonly UserHeroBusinessRules _userHeroBusinessRules;

    public UserHeroManager(IUserHeroRepository userHeroRepository, UserHeroBusinessRules userHeroBusinessRules)
    {
        _userHeroRepository = userHeroRepository;
        _userHeroBusinessRules = userHeroBusinessRules;
    }

    public async Task<UserHero?> GetAsync(
        Expression<Func<UserHero, bool>> predicate,
        Func<IQueryable<UserHero>, IIncludableQueryable<UserHero, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserHero? userHero = await _userHeroRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userHero;
    }

    public async Task<IPaginate<UserHero>?> GetListAsync(
        Expression<Func<UserHero, bool>>? predicate = null,
        Func<IQueryable<UserHero>, IOrderedQueryable<UserHero>>? orderBy = null,
        Func<IQueryable<UserHero>, IIncludableQueryable<UserHero, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserHero> userHeroList = await _userHeroRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userHeroList;
    }

    public async Task<UserHero> AddAsync(UserHero userHero)
    {
        UserHero addedUserHero = await _userHeroRepository.AddAsync(userHero);

        return addedUserHero;
    }

    public async Task<UserHero> UpdateAsync(UserHero userHero)
    {
        UserHero updatedUserHero = await _userHeroRepository.UpdateAsync(userHero);

        return updatedUserHero;
    }

    public async Task<UserHero> DeleteAsync(UserHero userHero, bool permanent = false)
    {
        UserHero deletedUserHero = await _userHeroRepository.DeleteAsync(userHero);

        return deletedUserHero;
    }
}

using Application.Features.UserPets.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserPets;

public class UserPetManager : IUserPetService
{
    private readonly IUserPetRepository _userPetRepository;
    private readonly UserPetBusinessRules _userPetBusinessRules;

    public UserPetManager(IUserPetRepository userPetRepository, UserPetBusinessRules userPetBusinessRules)
    {
        _userPetRepository = userPetRepository;
        _userPetBusinessRules = userPetBusinessRules;
    }

    public async Task<UserPet?> GetAsync(
        Expression<Func<UserPet, bool>> predicate,
        Func<IQueryable<UserPet>, IIncludableQueryable<UserPet, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserPet? userPet = await _userPetRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userPet;
    }

    public async Task<IPaginate<UserPet>?> GetListAsync(
        Expression<Func<UserPet, bool>>? predicate = null,
        Func<IQueryable<UserPet>, IOrderedQueryable<UserPet>>? orderBy = null,
        Func<IQueryable<UserPet>, IIncludableQueryable<UserPet, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserPet> userPetList = await _userPetRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userPetList;
    }

    public async Task<UserPet> AddAsync(UserPet userPet)
    {
        UserPet addedUserPet = await _userPetRepository.AddAsync(userPet);

        return addedUserPet;
    }

    public async Task<UserPet> UpdateAsync(UserPet userPet)
    {
        UserPet updatedUserPet = await _userPetRepository.UpdateAsync(userPet);

        return updatedUserPet;
    }

    public async Task<UserPet> DeleteAsync(UserPet userPet, bool permanent = false)
    {
        UserPet deletedUserPet = await _userPetRepository.DeleteAsync(userPet);

        return deletedUserPet;
    }
}

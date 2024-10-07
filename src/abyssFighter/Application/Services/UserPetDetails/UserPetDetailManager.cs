using Application.Features.UserPetDetails.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserPetDetails;

public class UserPetDetailManager : IUserPetDetailService
{
    private readonly IUserPetDetailRepository _userPetDetailRepository;
    private readonly UserPetDetailBusinessRules _userPetDetailBusinessRules;

    public UserPetDetailManager(IUserPetDetailRepository userPetDetailRepository, UserPetDetailBusinessRules userPetDetailBusinessRules)
    {
        _userPetDetailRepository = userPetDetailRepository;
        _userPetDetailBusinessRules = userPetDetailBusinessRules;
    }

    public async Task<UserPetDetail?> GetAsync(
        Expression<Func<UserPetDetail, bool>> predicate,
        Func<IQueryable<UserPetDetail>, IIncludableQueryable<UserPetDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserPetDetail? userPetDetail = await _userPetDetailRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userPetDetail;
    }

    public async Task<IPaginate<UserPetDetail>?> GetListAsync(
        Expression<Func<UserPetDetail, bool>>? predicate = null,
        Func<IQueryable<UserPetDetail>, IOrderedQueryable<UserPetDetail>>? orderBy = null,
        Func<IQueryable<UserPetDetail>, IIncludableQueryable<UserPetDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserPetDetail> userPetDetailList = await _userPetDetailRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userPetDetailList;
    }

    public async Task<UserPetDetail> AddAsync(UserPetDetail userPetDetail)
    {
        UserPetDetail addedUserPetDetail = await _userPetDetailRepository.AddAsync(userPetDetail);

        return addedUserPetDetail;
    }

    public async Task<UserPetDetail> UpdateAsync(UserPetDetail userPetDetail)
    {
        UserPetDetail updatedUserPetDetail = await _userPetDetailRepository.UpdateAsync(userPetDetail);

        return updatedUserPetDetail;
    }

    public async Task<UserPetDetail> DeleteAsync(UserPetDetail userPetDetail, bool permanent = false)
    {
        UserPetDetail deletedUserPetDetail = await _userPetDetailRepository.DeleteAsync(userPetDetail);

        return deletedUserPetDetail;
    }
}

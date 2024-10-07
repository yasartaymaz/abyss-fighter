using Application.Features.DefinitionWeaponTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionWeaponTypes;

public class DefinitionWeaponTypeManager : IDefinitionWeaponTypeService
{
    private readonly IDefinitionWeaponTypeRepository _definitionWeaponTypeRepository;
    private readonly DefinitionWeaponTypeBusinessRules _definitionWeaponTypeBusinessRules;

    public DefinitionWeaponTypeManager(IDefinitionWeaponTypeRepository definitionWeaponTypeRepository, DefinitionWeaponTypeBusinessRules definitionWeaponTypeBusinessRules)
    {
        _definitionWeaponTypeRepository = definitionWeaponTypeRepository;
        _definitionWeaponTypeBusinessRules = definitionWeaponTypeBusinessRules;
    }

    public async Task<DefinitionWeaponType?> GetAsync(
        Expression<Func<DefinitionWeaponType, bool>> predicate,
        Func<IQueryable<DefinitionWeaponType>, IIncludableQueryable<DefinitionWeaponType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        DefinitionWeaponType? definitionWeaponType = await _definitionWeaponTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return definitionWeaponType;
    }

    public async Task<IPaginate<DefinitionWeaponType>?> GetListAsync(
        Expression<Func<DefinitionWeaponType, bool>>? predicate = null,
        Func<IQueryable<DefinitionWeaponType>, IOrderedQueryable<DefinitionWeaponType>>? orderBy = null,
        Func<IQueryable<DefinitionWeaponType>, IIncludableQueryable<DefinitionWeaponType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<DefinitionWeaponType> definitionWeaponTypeList = await _definitionWeaponTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return definitionWeaponTypeList;
    }

    public async Task<DefinitionWeaponType> AddAsync(DefinitionWeaponType definitionWeaponType)
    {
        DefinitionWeaponType addedDefinitionWeaponType = await _definitionWeaponTypeRepository.AddAsync(definitionWeaponType);

        return addedDefinitionWeaponType;
    }

    public async Task<DefinitionWeaponType> UpdateAsync(DefinitionWeaponType definitionWeaponType)
    {
        DefinitionWeaponType updatedDefinitionWeaponType = await _definitionWeaponTypeRepository.UpdateAsync(definitionWeaponType);

        return updatedDefinitionWeaponType;
    }

    public async Task<DefinitionWeaponType> DeleteAsync(DefinitionWeaponType definitionWeaponType, bool permanent = false)
    {
        DefinitionWeaponType deletedDefinitionWeaponType = await _definitionWeaponTypeRepository.DeleteAsync(definitionWeaponType);

        return deletedDefinitionWeaponType;
    }
}

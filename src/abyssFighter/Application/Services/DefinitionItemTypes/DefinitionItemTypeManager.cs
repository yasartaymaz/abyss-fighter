using Application.Features.DefinitionItemTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionItemTypes;

public class DefinitionItemTypeManager : IDefinitionItemTypeService
{
    private readonly IDefinitionItemTypeRepository _definitionItemTypeRepository;
    private readonly DefinitionItemTypeBusinessRules _definitionItemTypeBusinessRules;

    public DefinitionItemTypeManager(IDefinitionItemTypeRepository definitionItemTypeRepository, DefinitionItemTypeBusinessRules definitionItemTypeBusinessRules)
    {
        _definitionItemTypeRepository = definitionItemTypeRepository;
        _definitionItemTypeBusinessRules = definitionItemTypeBusinessRules;
    }

    public async Task<DefinitionItemType?> GetAsync(
        Expression<Func<DefinitionItemType, bool>> predicate,
        Func<IQueryable<DefinitionItemType>, IIncludableQueryable<DefinitionItemType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        DefinitionItemType? definitionItemType = await _definitionItemTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return definitionItemType;
    }

    public async Task<IPaginate<DefinitionItemType>?> GetListAsync(
        Expression<Func<DefinitionItemType, bool>>? predicate = null,
        Func<IQueryable<DefinitionItemType>, IOrderedQueryable<DefinitionItemType>>? orderBy = null,
        Func<IQueryable<DefinitionItemType>, IIncludableQueryable<DefinitionItemType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<DefinitionItemType> definitionItemTypeList = await _definitionItemTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return definitionItemTypeList;
    }

    public async Task<DefinitionItemType> AddAsync(DefinitionItemType definitionItemType)
    {
        DefinitionItemType addedDefinitionItemType = await _definitionItemTypeRepository.AddAsync(definitionItemType);

        return addedDefinitionItemType;
    }

    public async Task<DefinitionItemType> UpdateAsync(DefinitionItemType definitionItemType)
    {
        DefinitionItemType updatedDefinitionItemType = await _definitionItemTypeRepository.UpdateAsync(definitionItemType);

        return updatedDefinitionItemType;
    }

    public async Task<DefinitionItemType> DeleteAsync(DefinitionItemType definitionItemType, bool permanent = false)
    {
        DefinitionItemType deletedDefinitionItemType = await _definitionItemTypeRepository.DeleteAsync(definitionItemType);

        return deletedDefinitionItemType;
    }
}

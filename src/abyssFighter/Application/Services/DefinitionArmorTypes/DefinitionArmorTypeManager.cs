using Application.Features.DefinitionArmorTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionArmorTypes;

public class DefinitionArmorTypeManager : IDefinitionArmorTypeService
{
    private readonly IDefinitionArmorTypeRepository _definitionArmorTypeRepository;
    private readonly DefinitionArmorTypeBusinessRules _definitionArmorTypeBusinessRules;

    public DefinitionArmorTypeManager(IDefinitionArmorTypeRepository definitionArmorTypeRepository, DefinitionArmorTypeBusinessRules definitionArmorTypeBusinessRules)
    {
        _definitionArmorTypeRepository = definitionArmorTypeRepository;
        _definitionArmorTypeBusinessRules = definitionArmorTypeBusinessRules;
    }

    public async Task<DefinitionArmorType?> GetAsync(
        Expression<Func<DefinitionArmorType, bool>> predicate,
        Func<IQueryable<DefinitionArmorType>, IIncludableQueryable<DefinitionArmorType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        DefinitionArmorType? definitionArmorType = await _definitionArmorTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return definitionArmorType;
    }

    public async Task<IPaginate<DefinitionArmorType>?> GetListAsync(
        Expression<Func<DefinitionArmorType, bool>>? predicate = null,
        Func<IQueryable<DefinitionArmorType>, IOrderedQueryable<DefinitionArmorType>>? orderBy = null,
        Func<IQueryable<DefinitionArmorType>, IIncludableQueryable<DefinitionArmorType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<DefinitionArmorType> definitionArmorTypeList = await _definitionArmorTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return definitionArmorTypeList;
    }

    public async Task<DefinitionArmorType> AddAsync(DefinitionArmorType definitionArmorType)
    {
        DefinitionArmorType addedDefinitionArmorType = await _definitionArmorTypeRepository.AddAsync(definitionArmorType);

        return addedDefinitionArmorType;
    }

    public async Task<DefinitionArmorType> UpdateAsync(DefinitionArmorType definitionArmorType)
    {
        DefinitionArmorType updatedDefinitionArmorType = await _definitionArmorTypeRepository.UpdateAsync(definitionArmorType);

        return updatedDefinitionArmorType;
    }

    public async Task<DefinitionArmorType> DeleteAsync(DefinitionArmorType definitionArmorType, bool permanent = false)
    {
        DefinitionArmorType deletedDefinitionArmorType = await _definitionArmorTypeRepository.DeleteAsync(definitionArmorType);

        return deletedDefinitionArmorType;
    }
}

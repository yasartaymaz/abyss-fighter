using Application.Features.DefinitionPetTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionPetTypes;

public class DefinitionPetTypeManager : IDefinitionPetTypeService
{
    private readonly IDefinitionPetTypeRepository _definitionPetTypeRepository;
    private readonly DefinitionPetTypeBusinessRules _definitionPetTypeBusinessRules;

    public DefinitionPetTypeManager(IDefinitionPetTypeRepository definitionPetTypeRepository, DefinitionPetTypeBusinessRules definitionPetTypeBusinessRules)
    {
        _definitionPetTypeRepository = definitionPetTypeRepository;
        _definitionPetTypeBusinessRules = definitionPetTypeBusinessRules;
    }

    public async Task<DefinitionPetType?> GetAsync(
        Expression<Func<DefinitionPetType, bool>> predicate,
        Func<IQueryable<DefinitionPetType>, IIncludableQueryable<DefinitionPetType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        DefinitionPetType? definitionPetType = await _definitionPetTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return definitionPetType;
    }

    public async Task<IPaginate<DefinitionPetType>?> GetListAsync(
        Expression<Func<DefinitionPetType, bool>>? predicate = null,
        Func<IQueryable<DefinitionPetType>, IOrderedQueryable<DefinitionPetType>>? orderBy = null,
        Func<IQueryable<DefinitionPetType>, IIncludableQueryable<DefinitionPetType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<DefinitionPetType> definitionPetTypeList = await _definitionPetTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return definitionPetTypeList;
    }

    public async Task<DefinitionPetType> AddAsync(DefinitionPetType definitionPetType)
    {
        DefinitionPetType addedDefinitionPetType = await _definitionPetTypeRepository.AddAsync(definitionPetType);

        return addedDefinitionPetType;
    }

    public async Task<DefinitionPetType> UpdateAsync(DefinitionPetType definitionPetType)
    {
        DefinitionPetType updatedDefinitionPetType = await _definitionPetTypeRepository.UpdateAsync(definitionPetType);

        return updatedDefinitionPetType;
    }

    public async Task<DefinitionPetType> DeleteAsync(DefinitionPetType definitionPetType, bool permanent = false)
    {
        DefinitionPetType deletedDefinitionPetType = await _definitionPetTypeRepository.DeleteAsync(definitionPetType);

        return deletedDefinitionPetType;
    }
}

using Application.Features.DefinitionArmorParts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionArmorParts;

public class DefinitionArmorPartManager : IDefinitionArmorPartService
{
    private readonly IDefinitionArmorPartRepository _definitionArmorPartRepository;
    private readonly DefinitionArmorPartBusinessRules _definitionArmorPartBusinessRules;

    public DefinitionArmorPartManager(IDefinitionArmorPartRepository definitionArmorPartRepository, DefinitionArmorPartBusinessRules definitionArmorPartBusinessRules)
    {
        _definitionArmorPartRepository = definitionArmorPartRepository;
        _definitionArmorPartBusinessRules = definitionArmorPartBusinessRules;
    }

    public async Task<DefinitionArmorPart?> GetAsync(
        Expression<Func<DefinitionArmorPart, bool>> predicate,
        Func<IQueryable<DefinitionArmorPart>, IIncludableQueryable<DefinitionArmorPart, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        DefinitionArmorPart? definitionArmorPart = await _definitionArmorPartRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return definitionArmorPart;
    }

    public async Task<IPaginate<DefinitionArmorPart>?> GetListAsync(
        Expression<Func<DefinitionArmorPart, bool>>? predicate = null,
        Func<IQueryable<DefinitionArmorPart>, IOrderedQueryable<DefinitionArmorPart>>? orderBy = null,
        Func<IQueryable<DefinitionArmorPart>, IIncludableQueryable<DefinitionArmorPart, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<DefinitionArmorPart> definitionArmorPartList = await _definitionArmorPartRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return definitionArmorPartList;
    }

    public async Task<DefinitionArmorPart> AddAsync(DefinitionArmorPart definitionArmorPart)
    {
        DefinitionArmorPart addedDefinitionArmorPart = await _definitionArmorPartRepository.AddAsync(definitionArmorPart);

        return addedDefinitionArmorPart;
    }

    public async Task<DefinitionArmorPart> UpdateAsync(DefinitionArmorPart definitionArmorPart)
    {
        DefinitionArmorPart updatedDefinitionArmorPart = await _definitionArmorPartRepository.UpdateAsync(definitionArmorPart);

        return updatedDefinitionArmorPart;
    }

    public async Task<DefinitionArmorPart> DeleteAsync(DefinitionArmorPart definitionArmorPart, bool permanent = false)
    {
        DefinitionArmorPart deletedDefinitionArmorPart = await _definitionArmorPartRepository.DeleteAsync(definitionArmorPart);

        return deletedDefinitionArmorPart;
    }
}

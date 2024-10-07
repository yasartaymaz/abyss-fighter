using Application.Features.DefinitionItems.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionItems;

public class DefinitionItemManager : IDefinitionItemService
{
    private readonly IDefinitionItemRepository _definitionItemRepository;
    private readonly DefinitionItemBusinessRules _definitionItemBusinessRules;

    public DefinitionItemManager(IDefinitionItemRepository definitionItemRepository, DefinitionItemBusinessRules definitionItemBusinessRules)
    {
        _definitionItemRepository = definitionItemRepository;
        _definitionItemBusinessRules = definitionItemBusinessRules;
    }

    public async Task<DefinitionItem?> GetAsync(
        Expression<Func<DefinitionItem, bool>> predicate,
        Func<IQueryable<DefinitionItem>, IIncludableQueryable<DefinitionItem, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        DefinitionItem? definitionItem = await _definitionItemRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return definitionItem;
    }

    public async Task<IPaginate<DefinitionItem>?> GetListAsync(
        Expression<Func<DefinitionItem, bool>>? predicate = null,
        Func<IQueryable<DefinitionItem>, IOrderedQueryable<DefinitionItem>>? orderBy = null,
        Func<IQueryable<DefinitionItem>, IIncludableQueryable<DefinitionItem, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<DefinitionItem> definitionItemList = await _definitionItemRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return definitionItemList;
    }

    public async Task<DefinitionItem> AddAsync(DefinitionItem definitionItem)
    {
        DefinitionItem addedDefinitionItem = await _definitionItemRepository.AddAsync(definitionItem);

        return addedDefinitionItem;
    }

    public async Task<DefinitionItem> UpdateAsync(DefinitionItem definitionItem)
    {
        DefinitionItem updatedDefinitionItem = await _definitionItemRepository.UpdateAsync(definitionItem);

        return updatedDefinitionItem;
    }

    public async Task<DefinitionItem> DeleteAsync(DefinitionItem definitionItem, bool permanent = false)
    {
        DefinitionItem deletedDefinitionItem = await _definitionItemRepository.DeleteAsync(definitionItem);

        return deletedDefinitionItem;
    }
}

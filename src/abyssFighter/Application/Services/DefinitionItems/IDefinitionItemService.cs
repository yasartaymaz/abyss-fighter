using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionItems;

public interface IDefinitionItemService
{
    Task<DefinitionItem?> GetAsync(
        Expression<Func<DefinitionItem, bool>> predicate,
        Func<IQueryable<DefinitionItem>, IIncludableQueryable<DefinitionItem, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<DefinitionItem>?> GetListAsync(
        Expression<Func<DefinitionItem, bool>>? predicate = null,
        Func<IQueryable<DefinitionItem>, IOrderedQueryable<DefinitionItem>>? orderBy = null,
        Func<IQueryable<DefinitionItem>, IIncludableQueryable<DefinitionItem, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<DefinitionItem> AddAsync(DefinitionItem definitionItem);
    Task<DefinitionItem> UpdateAsync(DefinitionItem definitionItem);
    Task<DefinitionItem> DeleteAsync(DefinitionItem definitionItem, bool permanent = false);
}

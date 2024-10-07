using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionItemTypes;

public interface IDefinitionItemTypeService
{
    Task<DefinitionItemType?> GetAsync(
        Expression<Func<DefinitionItemType, bool>> predicate,
        Func<IQueryable<DefinitionItemType>, IIncludableQueryable<DefinitionItemType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<DefinitionItemType>?> GetListAsync(
        Expression<Func<DefinitionItemType, bool>>? predicate = null,
        Func<IQueryable<DefinitionItemType>, IOrderedQueryable<DefinitionItemType>>? orderBy = null,
        Func<IQueryable<DefinitionItemType>, IIncludableQueryable<DefinitionItemType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<DefinitionItemType> AddAsync(DefinitionItemType definitionItemType);
    Task<DefinitionItemType> UpdateAsync(DefinitionItemType definitionItemType);
    Task<DefinitionItemType> DeleteAsync(DefinitionItemType definitionItemType, bool permanent = false);
}

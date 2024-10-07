using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionArmorTypes;

public interface IDefinitionArmorTypeService
{
    Task<DefinitionArmorType?> GetAsync(
        Expression<Func<DefinitionArmorType, bool>> predicate,
        Func<IQueryable<DefinitionArmorType>, IIncludableQueryable<DefinitionArmorType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<DefinitionArmorType>?> GetListAsync(
        Expression<Func<DefinitionArmorType, bool>>? predicate = null,
        Func<IQueryable<DefinitionArmorType>, IOrderedQueryable<DefinitionArmorType>>? orderBy = null,
        Func<IQueryable<DefinitionArmorType>, IIncludableQueryable<DefinitionArmorType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<DefinitionArmorType> AddAsync(DefinitionArmorType definitionArmorType);
    Task<DefinitionArmorType> UpdateAsync(DefinitionArmorType definitionArmorType);
    Task<DefinitionArmorType> DeleteAsync(DefinitionArmorType definitionArmorType, bool permanent = false);
}

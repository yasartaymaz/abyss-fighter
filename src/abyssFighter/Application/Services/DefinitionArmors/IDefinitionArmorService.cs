using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionArmors;

public interface IDefinitionArmorService
{
    Task<DefinitionArmor?> GetAsync(
        Expression<Func<DefinitionArmor, bool>> predicate,
        Func<IQueryable<DefinitionArmor>, IIncludableQueryable<DefinitionArmor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<DefinitionArmor>?> GetListAsync(
        Expression<Func<DefinitionArmor, bool>>? predicate = null,
        Func<IQueryable<DefinitionArmor>, IOrderedQueryable<DefinitionArmor>>? orderBy = null,
        Func<IQueryable<DefinitionArmor>, IIncludableQueryable<DefinitionArmor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<DefinitionArmor> AddAsync(DefinitionArmor definitionArmor);
    Task<DefinitionArmor> UpdateAsync(DefinitionArmor definitionArmor);
    Task<DefinitionArmor> DeleteAsync(DefinitionArmor definitionArmor, bool permanent = false);
}

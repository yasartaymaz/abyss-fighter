using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionArmorParts;

public interface IDefinitionArmorPartService
{
    Task<DefinitionArmorPart?> GetAsync(
        Expression<Func<DefinitionArmorPart, bool>> predicate,
        Func<IQueryable<DefinitionArmorPart>, IIncludableQueryable<DefinitionArmorPart, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<DefinitionArmorPart>?> GetListAsync(
        Expression<Func<DefinitionArmorPart, bool>>? predicate = null,
        Func<IQueryable<DefinitionArmorPart>, IOrderedQueryable<DefinitionArmorPart>>? orderBy = null,
        Func<IQueryable<DefinitionArmorPart>, IIncludableQueryable<DefinitionArmorPart, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<DefinitionArmorPart> AddAsync(DefinitionArmorPart definitionArmorPart);
    Task<DefinitionArmorPart> UpdateAsync(DefinitionArmorPart definitionArmorPart);
    Task<DefinitionArmorPart> DeleteAsync(DefinitionArmorPart definitionArmorPart, bool permanent = false);
}

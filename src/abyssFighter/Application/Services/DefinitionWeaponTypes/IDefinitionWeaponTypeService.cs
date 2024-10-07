using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionWeaponTypes;

public interface IDefinitionWeaponTypeService
{
    Task<DefinitionWeaponType?> GetAsync(
        Expression<Func<DefinitionWeaponType, bool>> predicate,
        Func<IQueryable<DefinitionWeaponType>, IIncludableQueryable<DefinitionWeaponType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<DefinitionWeaponType>?> GetListAsync(
        Expression<Func<DefinitionWeaponType, bool>>? predicate = null,
        Func<IQueryable<DefinitionWeaponType>, IOrderedQueryable<DefinitionWeaponType>>? orderBy = null,
        Func<IQueryable<DefinitionWeaponType>, IIncludableQueryable<DefinitionWeaponType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<DefinitionWeaponType> AddAsync(DefinitionWeaponType definitionWeaponType);
    Task<DefinitionWeaponType> UpdateAsync(DefinitionWeaponType definitionWeaponType);
    Task<DefinitionWeaponType> DeleteAsync(DefinitionWeaponType definitionWeaponType, bool permanent = false);
}

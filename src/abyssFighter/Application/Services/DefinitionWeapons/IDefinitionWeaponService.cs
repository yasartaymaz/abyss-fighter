using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionWeapons;

public interface IDefinitionWeaponService
{
    Task<DefinitionWeapon?> GetAsync(
        Expression<Func<DefinitionWeapon, bool>> predicate,
        Func<IQueryable<DefinitionWeapon>, IIncludableQueryable<DefinitionWeapon, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<DefinitionWeapon>?> GetListAsync(
        Expression<Func<DefinitionWeapon, bool>>? predicate = null,
        Func<IQueryable<DefinitionWeapon>, IOrderedQueryable<DefinitionWeapon>>? orderBy = null,
        Func<IQueryable<DefinitionWeapon>, IIncludableQueryable<DefinitionWeapon, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<DefinitionWeapon> AddAsync(DefinitionWeapon definitionWeapon);
    Task<DefinitionWeapon> UpdateAsync(DefinitionWeapon definitionWeapon);
    Task<DefinitionWeapon> DeleteAsync(DefinitionWeapon definitionWeapon, bool permanent = false);
}

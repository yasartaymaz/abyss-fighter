using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionHeroClasses;

public interface IDefinitionHeroClassService
{
    Task<DefinitionHeroClass?> GetAsync(
        Expression<Func<DefinitionHeroClass, bool>> predicate,
        Func<IQueryable<DefinitionHeroClass>, IIncludableQueryable<DefinitionHeroClass, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<DefinitionHeroClass>?> GetListAsync(
        Expression<Func<DefinitionHeroClass, bool>>? predicate = null,
        Func<IQueryable<DefinitionHeroClass>, IOrderedQueryable<DefinitionHeroClass>>? orderBy = null,
        Func<IQueryable<DefinitionHeroClass>, IIncludableQueryable<DefinitionHeroClass, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<DefinitionHeroClass> AddAsync(DefinitionHeroClass definitionHeroClass);
    Task<DefinitionHeroClass> UpdateAsync(DefinitionHeroClass definitionHeroClass);
    Task<DefinitionHeroClass> DeleteAsync(DefinitionHeroClass definitionHeroClass, bool permanent = false);
}

using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionPetTypes;

public interface IDefinitionPetTypeService
{
    Task<DefinitionPetType?> GetAsync(
        Expression<Func<DefinitionPetType, bool>> predicate,
        Func<IQueryable<DefinitionPetType>, IIncludableQueryable<DefinitionPetType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<DefinitionPetType>?> GetListAsync(
        Expression<Func<DefinitionPetType, bool>>? predicate = null,
        Func<IQueryable<DefinitionPetType>, IOrderedQueryable<DefinitionPetType>>? orderBy = null,
        Func<IQueryable<DefinitionPetType>, IIncludableQueryable<DefinitionPetType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<DefinitionPetType> AddAsync(DefinitionPetType definitionPetType);
    Task<DefinitionPetType> UpdateAsync(DefinitionPetType definitionPetType);
    Task<DefinitionPetType> DeleteAsync(DefinitionPetType definitionPetType, bool permanent = false);
}

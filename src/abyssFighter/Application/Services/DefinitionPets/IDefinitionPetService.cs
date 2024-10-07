using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionPets;

public interface IDefinitionPetService
{
    Task<DefinitionPet?> GetAsync(
        Expression<Func<DefinitionPet, bool>> predicate,
        Func<IQueryable<DefinitionPet>, IIncludableQueryable<DefinitionPet, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<DefinitionPet>?> GetListAsync(
        Expression<Func<DefinitionPet, bool>>? predicate = null,
        Func<IQueryable<DefinitionPet>, IOrderedQueryable<DefinitionPet>>? orderBy = null,
        Func<IQueryable<DefinitionPet>, IIncludableQueryable<DefinitionPet, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<DefinitionPet> AddAsync(DefinitionPet definitionPet);
    Task<DefinitionPet> UpdateAsync(DefinitionPet definitionPet);
    Task<DefinitionPet> DeleteAsync(DefinitionPet definitionPet, bool permanent = false);
}

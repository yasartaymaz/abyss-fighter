using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionWalletTypes;

public interface IDefinitionWalletTypeService
{
    Task<DefinitionWalletType?> GetAsync(
        Expression<Func<DefinitionWalletType, bool>> predicate,
        Func<IQueryable<DefinitionWalletType>, IIncludableQueryable<DefinitionWalletType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<DefinitionWalletType>?> GetListAsync(
        Expression<Func<DefinitionWalletType, bool>>? predicate = null,
        Func<IQueryable<DefinitionWalletType>, IOrderedQueryable<DefinitionWalletType>>? orderBy = null,
        Func<IQueryable<DefinitionWalletType>, IIncludableQueryable<DefinitionWalletType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<DefinitionWalletType> AddAsync(DefinitionWalletType definitionWalletType);
    Task<DefinitionWalletType> UpdateAsync(DefinitionWalletType definitionWalletType);
    Task<DefinitionWalletType> DeleteAsync(DefinitionWalletType definitionWalletType, bool permanent = false);
}

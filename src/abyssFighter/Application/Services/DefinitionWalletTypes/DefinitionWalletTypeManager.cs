using Application.Features.DefinitionWalletTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionWalletTypes;

public class DefinitionWalletTypeManager : IDefinitionWalletTypeService
{
    private readonly IDefinitionWalletTypeRepository _definitionWalletTypeRepository;
    private readonly DefinitionWalletTypeBusinessRules _definitionWalletTypeBusinessRules;

    public DefinitionWalletTypeManager(IDefinitionWalletTypeRepository definitionWalletTypeRepository, DefinitionWalletTypeBusinessRules definitionWalletTypeBusinessRules)
    {
        _definitionWalletTypeRepository = definitionWalletTypeRepository;
        _definitionWalletTypeBusinessRules = definitionWalletTypeBusinessRules;
    }

    public async Task<DefinitionWalletType?> GetAsync(
        Expression<Func<DefinitionWalletType, bool>> predicate,
        Func<IQueryable<DefinitionWalletType>, IIncludableQueryable<DefinitionWalletType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        DefinitionWalletType? definitionWalletType = await _definitionWalletTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return definitionWalletType;
    }

    public async Task<IPaginate<DefinitionWalletType>?> GetListAsync(
        Expression<Func<DefinitionWalletType, bool>>? predicate = null,
        Func<IQueryable<DefinitionWalletType>, IOrderedQueryable<DefinitionWalletType>>? orderBy = null,
        Func<IQueryable<DefinitionWalletType>, IIncludableQueryable<DefinitionWalletType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<DefinitionWalletType> definitionWalletTypeList = await _definitionWalletTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return definitionWalletTypeList;
    }

    public async Task<DefinitionWalletType> AddAsync(DefinitionWalletType definitionWalletType)
    {
        DefinitionWalletType addedDefinitionWalletType = await _definitionWalletTypeRepository.AddAsync(definitionWalletType);

        return addedDefinitionWalletType;
    }

    public async Task<DefinitionWalletType> UpdateAsync(DefinitionWalletType definitionWalletType)
    {
        DefinitionWalletType updatedDefinitionWalletType = await _definitionWalletTypeRepository.UpdateAsync(definitionWalletType);

        return updatedDefinitionWalletType;
    }

    public async Task<DefinitionWalletType> DeleteAsync(DefinitionWalletType definitionWalletType, bool permanent = false)
    {
        DefinitionWalletType deletedDefinitionWalletType = await _definitionWalletTypeRepository.DeleteAsync(definitionWalletType);

        return deletedDefinitionWalletType;
    }
}

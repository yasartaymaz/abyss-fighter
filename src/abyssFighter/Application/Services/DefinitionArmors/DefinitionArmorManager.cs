using Application.Features.DefinitionArmors.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionArmors;

public class DefinitionArmorManager : IDefinitionArmorService
{
    private readonly IDefinitionArmorRepository _definitionArmorRepository;
    private readonly DefinitionArmorBusinessRules _definitionArmorBusinessRules;

    public DefinitionArmorManager(IDefinitionArmorRepository definitionArmorRepository, DefinitionArmorBusinessRules definitionArmorBusinessRules)
    {
        _definitionArmorRepository = definitionArmorRepository;
        _definitionArmorBusinessRules = definitionArmorBusinessRules;
    }

    public async Task<DefinitionArmor?> GetAsync(
        Expression<Func<DefinitionArmor, bool>> predicate,
        Func<IQueryable<DefinitionArmor>, IIncludableQueryable<DefinitionArmor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        DefinitionArmor? definitionArmor = await _definitionArmorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return definitionArmor;
    }

    public async Task<IPaginate<DefinitionArmor>?> GetListAsync(
        Expression<Func<DefinitionArmor, bool>>? predicate = null,
        Func<IQueryable<DefinitionArmor>, IOrderedQueryable<DefinitionArmor>>? orderBy = null,
        Func<IQueryable<DefinitionArmor>, IIncludableQueryable<DefinitionArmor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<DefinitionArmor> definitionArmorList = await _definitionArmorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return definitionArmorList;
    }

    public async Task<DefinitionArmor> AddAsync(DefinitionArmor definitionArmor)
    {
        DefinitionArmor addedDefinitionArmor = await _definitionArmorRepository.AddAsync(definitionArmor);

        return addedDefinitionArmor;
    }

    public async Task<DefinitionArmor> UpdateAsync(DefinitionArmor definitionArmor)
    {
        DefinitionArmor updatedDefinitionArmor = await _definitionArmorRepository.UpdateAsync(definitionArmor);

        return updatedDefinitionArmor;
    }

    public async Task<DefinitionArmor> DeleteAsync(DefinitionArmor definitionArmor, bool permanent = false)
    {
        DefinitionArmor deletedDefinitionArmor = await _definitionArmorRepository.DeleteAsync(definitionArmor);

        return deletedDefinitionArmor;
    }
}

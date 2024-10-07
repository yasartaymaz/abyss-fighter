using Application.Features.DefinitionWeapons.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionWeapons;

public class DefinitionWeaponManager : IDefinitionWeaponService
{
    private readonly IDefinitionWeaponRepository _definitionWeaponRepository;
    private readonly DefinitionWeaponBusinessRules _definitionWeaponBusinessRules;

    public DefinitionWeaponManager(IDefinitionWeaponRepository definitionWeaponRepository, DefinitionWeaponBusinessRules definitionWeaponBusinessRules)
    {
        _definitionWeaponRepository = definitionWeaponRepository;
        _definitionWeaponBusinessRules = definitionWeaponBusinessRules;
    }

    public async Task<DefinitionWeapon?> GetAsync(
        Expression<Func<DefinitionWeapon, bool>> predicate,
        Func<IQueryable<DefinitionWeapon>, IIncludableQueryable<DefinitionWeapon, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        DefinitionWeapon? definitionWeapon = await _definitionWeaponRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return definitionWeapon;
    }

    public async Task<IPaginate<DefinitionWeapon>?> GetListAsync(
        Expression<Func<DefinitionWeapon, bool>>? predicate = null,
        Func<IQueryable<DefinitionWeapon>, IOrderedQueryable<DefinitionWeapon>>? orderBy = null,
        Func<IQueryable<DefinitionWeapon>, IIncludableQueryable<DefinitionWeapon, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<DefinitionWeapon> definitionWeaponList = await _definitionWeaponRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return definitionWeaponList;
    }

    public async Task<DefinitionWeapon> AddAsync(DefinitionWeapon definitionWeapon)
    {
        DefinitionWeapon addedDefinitionWeapon = await _definitionWeaponRepository.AddAsync(definitionWeapon);

        return addedDefinitionWeapon;
    }

    public async Task<DefinitionWeapon> UpdateAsync(DefinitionWeapon definitionWeapon)
    {
        DefinitionWeapon updatedDefinitionWeapon = await _definitionWeaponRepository.UpdateAsync(definitionWeapon);

        return updatedDefinitionWeapon;
    }

    public async Task<DefinitionWeapon> DeleteAsync(DefinitionWeapon definitionWeapon, bool permanent = false)
    {
        DefinitionWeapon deletedDefinitionWeapon = await _definitionWeaponRepository.DeleteAsync(definitionWeapon);

        return deletedDefinitionWeapon;
    }
}

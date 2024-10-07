using Application.Features.DefinitionHeroClasses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionHeroClasses;

public class DefinitionHeroClassManager : IDefinitionHeroClassService
{
    private readonly IDefinitionHeroClassRepository _definitionHeroClassRepository;
    private readonly DefinitionHeroClassBusinessRules _definitionHeroClassBusinessRules;

    public DefinitionHeroClassManager(IDefinitionHeroClassRepository definitionHeroClassRepository, DefinitionHeroClassBusinessRules definitionHeroClassBusinessRules)
    {
        _definitionHeroClassRepository = definitionHeroClassRepository;
        _definitionHeroClassBusinessRules = definitionHeroClassBusinessRules;
    }

    public async Task<DefinitionHeroClass?> GetAsync(
        Expression<Func<DefinitionHeroClass, bool>> predicate,
        Func<IQueryable<DefinitionHeroClass>, IIncludableQueryable<DefinitionHeroClass, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        DefinitionHeroClass? definitionHeroClass = await _definitionHeroClassRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return definitionHeroClass;
    }

    public async Task<IPaginate<DefinitionHeroClass>?> GetListAsync(
        Expression<Func<DefinitionHeroClass, bool>>? predicate = null,
        Func<IQueryable<DefinitionHeroClass>, IOrderedQueryable<DefinitionHeroClass>>? orderBy = null,
        Func<IQueryable<DefinitionHeroClass>, IIncludableQueryable<DefinitionHeroClass, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<DefinitionHeroClass> definitionHeroClassList = await _definitionHeroClassRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return definitionHeroClassList;
    }

    public async Task<DefinitionHeroClass> AddAsync(DefinitionHeroClass definitionHeroClass)
    {
        DefinitionHeroClass addedDefinitionHeroClass = await _definitionHeroClassRepository.AddAsync(definitionHeroClass);

        return addedDefinitionHeroClass;
    }

    public async Task<DefinitionHeroClass> UpdateAsync(DefinitionHeroClass definitionHeroClass)
    {
        DefinitionHeroClass updatedDefinitionHeroClass = await _definitionHeroClassRepository.UpdateAsync(definitionHeroClass);

        return updatedDefinitionHeroClass;
    }

    public async Task<DefinitionHeroClass> DeleteAsync(DefinitionHeroClass definitionHeroClass, bool permanent = false)
    {
        DefinitionHeroClass deletedDefinitionHeroClass = await _definitionHeroClassRepository.DeleteAsync(definitionHeroClass);

        return deletedDefinitionHeroClass;
    }
}

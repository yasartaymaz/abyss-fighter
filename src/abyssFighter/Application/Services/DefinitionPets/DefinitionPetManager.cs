using Application.Features.DefinitionPets.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DefinitionPets;

public class DefinitionPetManager : IDefinitionPetService
{
    private readonly IDefinitionPetRepository _definitionPetRepository;
    private readonly DefinitionPetBusinessRules _definitionPetBusinessRules;

    public DefinitionPetManager(IDefinitionPetRepository definitionPetRepository, DefinitionPetBusinessRules definitionPetBusinessRules)
    {
        _definitionPetRepository = definitionPetRepository;
        _definitionPetBusinessRules = definitionPetBusinessRules;
    }

    public async Task<DefinitionPet?> GetAsync(
        Expression<Func<DefinitionPet, bool>> predicate,
        Func<IQueryable<DefinitionPet>, IIncludableQueryable<DefinitionPet, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        DefinitionPet? definitionPet = await _definitionPetRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return definitionPet;
    }

    public async Task<IPaginate<DefinitionPet>?> GetListAsync(
        Expression<Func<DefinitionPet, bool>>? predicate = null,
        Func<IQueryable<DefinitionPet>, IOrderedQueryable<DefinitionPet>>? orderBy = null,
        Func<IQueryable<DefinitionPet>, IIncludableQueryable<DefinitionPet, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<DefinitionPet> definitionPetList = await _definitionPetRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return definitionPetList;
    }

    public async Task<DefinitionPet> AddAsync(DefinitionPet definitionPet)
    {
        DefinitionPet addedDefinitionPet = await _definitionPetRepository.AddAsync(definitionPet);

        return addedDefinitionPet;
    }

    public async Task<DefinitionPet> UpdateAsync(DefinitionPet definitionPet)
    {
        DefinitionPet updatedDefinitionPet = await _definitionPetRepository.UpdateAsync(definitionPet);

        return updatedDefinitionPet;
    }

    public async Task<DefinitionPet> DeleteAsync(DefinitionPet definitionPet, bool permanent = false)
    {
        DefinitionPet deletedDefinitionPet = await _definitionPetRepository.DeleteAsync(definitionPet);

        return deletedDefinitionPet;
    }
}

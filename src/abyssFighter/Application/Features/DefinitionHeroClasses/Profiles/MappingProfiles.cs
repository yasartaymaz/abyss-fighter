using Application.Features.DefinitionHeroClasses.Commands.Create;
using Application.Features.DefinitionHeroClasses.Commands.Delete;
using Application.Features.DefinitionHeroClasses.Commands.Update;
using Application.Features.DefinitionHeroClasses.Queries.GetById;
using Application.Features.DefinitionHeroClasses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.DefinitionHeroClasses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDefinitionHeroClassCommand, DefinitionHeroClass>();
        CreateMap<DefinitionHeroClass, CreatedDefinitionHeroClassResponse>();

        CreateMap<UpdateDefinitionHeroClassCommand, DefinitionHeroClass>();
        CreateMap<DefinitionHeroClass, UpdatedDefinitionHeroClassResponse>();

        CreateMap<DeleteDefinitionHeroClassCommand, DefinitionHeroClass>();
        CreateMap<DefinitionHeroClass, DeletedDefinitionHeroClassResponse>();

        CreateMap<DefinitionHeroClass, GetByIdDefinitionHeroClassResponse>();

        CreateMap<DefinitionHeroClass, GetListDefinitionHeroClassListItemDto>();
        CreateMap<IPaginate<DefinitionHeroClass>, GetListResponse<GetListDefinitionHeroClassListItemDto>>();
    }
}
using Application.Features.DefinitionPetTypes.Commands.Create;
using Application.Features.DefinitionPetTypes.Commands.Delete;
using Application.Features.DefinitionPetTypes.Commands.Update;
using Application.Features.DefinitionPetTypes.Queries.GetById;
using Application.Features.DefinitionPetTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.DefinitionPetTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDefinitionPetTypeCommand, DefinitionPetType>();
        CreateMap<DefinitionPetType, CreatedDefinitionPetTypeResponse>();

        CreateMap<UpdateDefinitionPetTypeCommand, DefinitionPetType>();
        CreateMap<DefinitionPetType, UpdatedDefinitionPetTypeResponse>();

        CreateMap<DeleteDefinitionPetTypeCommand, DefinitionPetType>();
        CreateMap<DefinitionPetType, DeletedDefinitionPetTypeResponse>();

        CreateMap<DefinitionPetType, GetByIdDefinitionPetTypeResponse>();

        CreateMap<DefinitionPetType, GetListDefinitionPetTypeListItemDto>();
        CreateMap<IPaginate<DefinitionPetType>, GetListResponse<GetListDefinitionPetTypeListItemDto>>();
    }
}
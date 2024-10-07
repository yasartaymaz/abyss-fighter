using Application.Features.DefinitionPets.Commands.Create;
using Application.Features.DefinitionPets.Commands.Delete;
using Application.Features.DefinitionPets.Commands.Update;
using Application.Features.DefinitionPets.Queries.GetById;
using Application.Features.DefinitionPets.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.DefinitionPets.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDefinitionPetCommand, DefinitionPet>();
        CreateMap<DefinitionPet, CreatedDefinitionPetResponse>();

        CreateMap<UpdateDefinitionPetCommand, DefinitionPet>();
        CreateMap<DefinitionPet, UpdatedDefinitionPetResponse>();

        CreateMap<DeleteDefinitionPetCommand, DefinitionPet>();
        CreateMap<DefinitionPet, DeletedDefinitionPetResponse>();

        CreateMap<DefinitionPet, GetByIdDefinitionPetResponse>();

        CreateMap<DefinitionPet, GetListDefinitionPetListItemDto>();
        CreateMap<IPaginate<DefinitionPet>, GetListResponse<GetListDefinitionPetListItemDto>>();
    }
}
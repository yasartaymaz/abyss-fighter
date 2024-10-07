using Application.Features.DefinitionArmors.Commands.Create;
using Application.Features.DefinitionArmors.Commands.Delete;
using Application.Features.DefinitionArmors.Commands.Update;
using Application.Features.DefinitionArmors.Queries.GetById;
using Application.Features.DefinitionArmors.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.DefinitionArmors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDefinitionArmorCommand, DefinitionArmor>();
        CreateMap<DefinitionArmor, CreatedDefinitionArmorResponse>();

        CreateMap<UpdateDefinitionArmorCommand, DefinitionArmor>();
        CreateMap<DefinitionArmor, UpdatedDefinitionArmorResponse>();

        CreateMap<DeleteDefinitionArmorCommand, DefinitionArmor>();
        CreateMap<DefinitionArmor, DeletedDefinitionArmorResponse>();

        CreateMap<DefinitionArmor, GetByIdDefinitionArmorResponse>();

        CreateMap<DefinitionArmor, GetListDefinitionArmorListItemDto>();
        CreateMap<IPaginate<DefinitionArmor>, GetListResponse<GetListDefinitionArmorListItemDto>>();
    }
}